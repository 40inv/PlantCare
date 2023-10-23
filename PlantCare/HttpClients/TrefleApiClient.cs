using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using PlantCare.Models;
using PlantCare.Options;
using PlantCare.Requests;
using Polly;
using Polly.Retry;
using System.Collections.Specialized;
using System.Web;

namespace PlantCare.HttpClients;

/// <summary>
/// Http Client for call to Trefle API.
/// </summary>
public class TrefleApiClient
{
    private readonly HttpClient _httpClient;
    private readonly TrefleApiOptions _apiOptions;
    private const int _maxApiCallRetries = 3;
    private readonly AsyncRetryPolicy<HttpResponseMessage> _asyncRetryPolicy =
        Policy
            .HandleResult<HttpResponseMessage>(response => !response.IsSuccessStatusCode)
            .WaitAndRetryAsync(_maxApiCallRetries, retryAttempt => TimeSpan.FromSeconds(retryAttempt));

    private static readonly JsonSerializerSettings _dezerializerSettings = new()
    {
        ContractResolver = new DefaultContractResolver
        {
            NamingStrategy = new SnakeCaseNamingStrategy()
        }
    };

    public TrefleApiClient(HttpClient httpClient, IOptions<TrefleApiOptions> apiOptions)
    {
        _httpClient = httpClient;
        _apiOptions = apiOptions.Value;
        _httpClient.BaseAddress = new Uri(_apiOptions.BaseUrl);
        _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {_apiOptions.ApiKey}");
    }

    /// <summary>
    /// Call to get plant models from Trefle.
    /// </summary>
    /// <returns>Read only collections of plant models.</returns>
    public async Task<IReadOnlyCollection<PlantModel>> GetPlantAsync(
        GetPlantsRequest request,
        CancellationToken cancellationToken)
    {
        string endpoint = _apiOptions.ListPlantsEndpoint;
        NameValueCollection query = HttpUtility.ParseQueryString(string.Empty);

        if (request.PageNumber.HasValue)
        {
            query["page"] = request.PageNumber.Value.ToString();
        }

        var result = await GetAsync<RootModel<List<PlantModel>>>($"{endpoint}?{query}", cancellationToken);
        return result?.Data ?? new List<PlantModel>(0);
    }

    /// <summary>
    /// Call to get detailed plant information by id. 
    /// </summary>
    /// <returns> Detailed plant model.</returns>
    public async Task<DetailedPlantModel> GetPlantByIdAsync(
        GetPlantByIdRequest request,
        CancellationToken cancellationToken)
    {
        string endpoint = _apiOptions.ListPlantsEndpoint;
        NameValueCollection query = HttpUtility.ParseQueryString(string.Empty);

        var result = await GetAsync<RootModel<DetailedPlantModel>>($"{endpoint}/{request.PlantId}", cancellationToken);

        return result?.Data;
    }

    private async Task<T> GetAsync<T>(string endpoint, CancellationToken cancellationToken)
    {
        HttpResponseMessage response =
            await _asyncRetryPolicy.ExecuteAsync(() => _httpClient.GetAsync(endpoint, cancellationToken));

        if (!response.IsSuccessStatusCode)
        {
            return default;
        }

        string content = await response.Content.ReadAsStringAsync(cancellationToken);

        var result = JsonConvert.DeserializeObject<T>(content, _dezerializerSettings);

        return result;

    }
}
