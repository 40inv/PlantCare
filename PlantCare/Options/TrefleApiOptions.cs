namespace PlantCare.Options;

/// <summary>
/// Good practice to add summary for each property
/// but for demo purposes summaries are not added.
/// </summary>
public record TrefleApiOptions
{
    public const string TrefleApi = "TrefleApi";

    public string BaseUrl { get; set; }
    public string ApiKey { get; set; }
    public string ListPlantsEndpoint { get; set; }
}