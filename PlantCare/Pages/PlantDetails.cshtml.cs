using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PlantCare.HttpClients;
using PlantCare.Models;
using PlantCare.Requests;

namespace PlantCare.Pages
{
    public class PlantDetailsModel : PageModel
    {
        public DetailedPlantModel Plant { get; set; }
        public List<Image> Images { get; set; } = new();

        private readonly TrefleApiClient _trefleApiClient;

        public PlantDetailsModel(TrefleApiClient trefleApiClient)
        {
            _trefleApiClient = trefleApiClient;
        }

        public async Task<IActionResult> OnGet(int id, CancellationToken cancellationToken)
        {
            var request = new GetPlantByIdRequest { PlantId = id };
            Plant = await _trefleApiClient.GetPlantByIdAsync(request, cancellationToken);

            if (Plant == null)
            {
                return NotFound();
            }

            if (Plant.MainSpecies.Images is null)
            {
                return Page();
            }

            Type imagesProperty = Plant.MainSpecies.Images.GetType();

            foreach (var propertyInfo in imagesProperty.GetProperties())
            {
                object value = propertyInfo.GetValue(Plant.MainSpecies.Images);

                if (value is List<Image> imageList)
                {
                    Images.AddRange(imageList);
                }
            }

            return Page();
        }
    }
}
