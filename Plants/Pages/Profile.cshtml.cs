using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Plants.Models;
using Plants.Repository;

namespace Plants.Views.Home
{
    public class ProfileModel : PageModel
    {
        public Plant Plant { get; set; }

        public Species species { get; set; }

        private ITrefleRepository repository;
        public ProfileModel(ITrefleRepository _repository, Plant plant)
        {
            this.repository = _repository;
            this.repository.GetPlantsAsync();
            this.Plant = plant;
        }

        //[BindProperty(SupportsGet = true)]
        //public List<apiData> apidata { get; private set; }

        public async Task OnGetAsync(int id)
        {
            this.species = this.Plant.GetPlantObject(id);
        }
    }
}
