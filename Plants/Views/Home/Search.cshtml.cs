using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Logging;
using PagedList.Mvc;
using Plants.Models;
using Plants.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Plants.Views.Home
{
    public class SearchModel : PageModel
    {
        public Plant Model { get; set; }

        ITrefleRepository repository;
        public SearchModel(ITrefleRepository _repository, Plant model)
        {
            repository = _repository;
            this.apidata = new List<apiData>();
            this.Model = model;
        }

        [BindProperty(SupportsGet = true)]
        public List<apiData> apidata { get; set; }

        public async Task OnGetAsync()
        {
            this.apidata= new List<apiData>();
            this.apidata = await repository.GetPlantsAsync();
            this.Model.AddPlants(apidata);
        }
    }
}