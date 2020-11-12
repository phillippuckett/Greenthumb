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
        public List<apiData> apiData { get; set; }
        public IEnumerable<apiData> iEnumApiData { get; set; }

        public SearchModel(ITrefleRepository r, Plant p)
        {
            this.repository = r;
            this.apiData = new List<apiData>();
            this.Plant = p;
        }

        // SEARCHING, SORTING, FILTERING, PAGINATION //

        public string CommonNameSort { get; set; }
        public string FamilyCommonNameSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public PaginatedList<apiData> ApiData { get; set; }

        public async Task OnGetAsync(string sortOrder, string currentFilter, string searchString, int? pageIndex)
        {
            CurrentSort = sortOrder;
            CommonNameSort = String.IsNullOrEmpty(sortOrder) ? "CommonNameDesc" : "";
            FamilyCommonNameSort = String.IsNullOrEmpty(sortOrder) ? "FamilyCommonNameDesc" : "";
            
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

            switch (sortOrder)
            {
                case "CommonNameDesc":
                    iEnumApiData = iEnumApiData.OrderBy(item => item.common_name);
                    break;
                case "FamilyCommonNameDesc":
                    iEnumApiData = iEnumApiData.OrderBy(item => item.family_common_name);
                    break;
                default:
                    iEnumApiData = iEnumApiData.OrderByDescending(item => item.common_name);
                    break;
            }

            int pageSize = 5;
            //ApiData = await PaginatedList<apiData>.CreateAsync(apiData, pageIndex ?? 1, pageSize);
        }
    }
}