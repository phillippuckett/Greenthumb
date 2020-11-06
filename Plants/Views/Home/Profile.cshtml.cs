using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Runtime.CompilerServices;
using Plants.Models;
using Plants.Repository;
using ApiApplication.Controllers;

namespace Plants.Views.Home
{
    public class ProfileModel : PageModel
    {
        public Plant y { get; set; }

        public apiData x { get; set; }

        private ITrefleRepository repository;
        public ProfileModel(ITrefleRepository _repository, Plant plant)
        {
            this.repository = _repository;
            this.repository.GetPlantsAsync();
            this.y = plant;
        }

        //[BindProperty(SupportsGet = true)]
        //public List<apiData> apidata { get; private set; }

        public async Task OnGetAsync(int id)
        {
            x = this.y.GetPlantObject(id);
        }
    }
}
