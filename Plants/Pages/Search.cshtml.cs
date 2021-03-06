using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Plants.Models;
using Plants.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Plants.Pages
{
    public class SearchModel : PageModel
    {

        // SEARCH MODEL //

        private ITrefleRepository repository;

        public Plant Plant { get; set; }

        [BindProperty(SupportsGet = true)]
        public List<Species> apiData { get; set; }
        public IEnumerable<Species> iEnumApiData { get; set; }

        public SearchModel(ITrefleRepository r, Plant p)
        {
            this.repository = r;
            this.apiData = new List<Species>();
            this.Plant = p;
        }

        // SEARCHING, SORTING, FILTERING, PAGINATION? //

        public int pageSize = 5;
        public string CommonNameSort { get; set; }
        public string FamilyCommonNameSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        //public PaginatedList<Species> ApiData { get; set; }

        public async Task OnGetAsync(string sortOrder, string currentFilter, string searchString, int? pageIndex)
        {
            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            this.CurrentFilter = searchString;

            this.apiData = await repository.GetPlantsAsync();
            if (!String.IsNullOrEmpty(searchString))
            {
                iEnumApiData = apiData.Where(item => item.common_name.Contains(searchString) || item.family_common_name.Contains(searchString));
            }
            else
            {
                iEnumApiData = this.apiData;
            }

            this.Plant.AddPlants(apiData);
            
            CurrentSort = sortOrder;
            CommonNameSort = String.IsNullOrEmpty(sortOrder) ? "descending" : "";

            switch (sortOrder)
            {
                case "descending":
                    iEnumApiData = iEnumApiData.OrderBy(item => item.common_name);
                    break;
                default:
                    iEnumApiData = iEnumApiData.OrderByDescending(item => item.common_name);
                    break;
            }            
            //ApiData = await PaginatedList<apiData>.CreateAsync(apiData, pageIndex ?? 1, pageSize);
        }
        
    }
}