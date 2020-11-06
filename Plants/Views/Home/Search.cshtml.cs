using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Plants.Models;
using Plants.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Plants.Views.Home
{
    public class SearchModel : PageModel
    {
        ITrefleRepository repository;

        public Plant Plant { get; set; }

        [BindProperty(SupportsGet = true)]
        public List<apiData> apiData { get; set; }

        public SearchModel(ITrefleRepository _repository, Plant plant)
        {
            this.repository = _repository;
            this.apiData = new List<apiData>();
            this.Plant = plant;
        }

        public async Task OnGetAsync()
        {
            this.apiData = await repository.GetPlantsAsync();
            this.Plant.AddPlants(apiData);
        }
    }
}