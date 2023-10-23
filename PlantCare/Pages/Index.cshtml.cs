using Microsoft.AspNetCore.Mvc.RazorPages;
using PlantCare.HttpClients;
using PlantCare.Models;
using PlantCare.Requests;

namespace PlantCare.Pages;

public class IndexModel : PageModel
{
    public IReadOnlyCollection<PlantModel> Plants { get; set; }

    public int CurrentPage { get; set; } = 1;

    public bool EnablePrevious => CurrentPage > 1;

    public bool EnableNext = true;

    private readonly TrefleApiClient _trefleApiClient;

    public IndexModel(TrefleApiClient trefleApiClient)
    {
        _trefleApiClient = trefleApiClient;
    }

    public async Task OnGet(int currentPage, CancellationToken cancellationToken)
    {
        CurrentPage = currentPage == 0 ? 1 : currentPage;

        var request = new GetPlantsRequest { PageNumber = CurrentPage };

        IReadOnlyCollection<PlantModel> nextPage = 
            await _trefleApiClient.GetPlantAsync(request, cancellationToken);
        EnableNext = nextPage.Count >= 20;
        Plants = nextPage;
    }
}
