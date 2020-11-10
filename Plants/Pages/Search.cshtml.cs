using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Plants.Models;
using Plants.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Plants.Pages
{
    public class SearchModel : PageModel
    {
        ITrefleRepository repository;

        //[BindProperty]
        //[BindProperty(SupportsGet = true)]
        public Plant Plant { get; set; }

        [BindProperty(SupportsGet = true)]
        public List<apiData> apiData { get; set; }

        public SearchModel(ITrefleRepository r, Plant p)
        {
            this.repository = r;
            this.apiData = new List<apiData>();
            this.Plant = p;
        }

        public async Task OnGetAsync()
        {
            this.apiData = await repository.GetPlantsAsync();
            this.Plant.AddPlants(apiData);
        }
    }
}