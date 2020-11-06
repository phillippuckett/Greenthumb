using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.Language;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using PagedList;
using Plants;
using Plants.Models;
using Plants.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace ApiApplication.Controllers
{
    [Route("/TrefleAPI")]
    [ApiController]
    public class TrefleController : Controller
    {
        private readonly ITrefleRepository repository;
        public Plant x;
        public TrefleController(ITrefleRepository _repository, Plant plantList)
        {
            this.repository = _repository;
            this.repository.GetPlantsAsync();
            x = plantList;
        }

        [HttpGet, Route("DataRequest")]
        public async Task<IActionResult> SortFilterPaginate(string sortOrder, string currentFilter, string searchString, int? pageNumber)
        {
            try
            {
                //ViewBag.CurrentSort = sortOrder;
                //ViewBag.SortCommonName = String.IsNullOrEmpty(sortOrder) ? "CommonNameDesc" : "";
                //ViewBag.SortSlug = String.IsNullOrEmpty(sortOrder) ? "SlugDesc" : "";
                //ViewBag.SortScientificName = String.IsNullOrEmpty(sortOrder) ? "ScientificNameDesc" : "";
                //ViewBag.SortYear = String.IsNullOrEmpty(sortOrder) ? "YearDesc" : "";
                //ViewBag.SortBibliography = String.IsNullOrEmpty(sortOrder) ? "BibliographyDesc" : "";
                //ViewBag.SortAuthor = String.IsNullOrEmpty(sortOrder) ? "AuthorDesc" : "";
                //ViewBag.SortStatus = String.IsNullOrEmpty(sortOrder) ? "StatusDesc" : "";
                //ViewBag.SortRank = String.IsNullOrEmpty(sortOrder) ? "RankDesc" : "";
                //ViewBag.SortFamilyCommonName = String.IsNullOrEmpty(sortOrder) ? "FamilyCommonNameDesc" : "";
                //ViewBag.SortGenusId = sortOrder == "GenusId" ? "GenusIdDesc" : "";
                //ViewBag.SortImageUrl = String.IsNullOrEmpty(sortOrder) ? "ImageUrlDesc" : "";
                //ViewBag.SortSynonyms = String.IsNullOrEmpty(sortOrder) ? "SynonymsDesc" : "";
                //ViewBag.SortGenus = String.IsNullOrEmpty(sortOrder) ? "GenusDesc" : "";
                //ViewBag.SortFamily = String.IsNullOrEmpty(sortOrder) ? "FamilyDesc" : "";             
                //ViewBag.SortPlantId = String.IsNullOrEmpty(sortOrder) ? "PlantIdDesc" : "";
                //ViewBag.SortId = sortOrder == "Id" ? "IdDesc" : "";
                //LinksDesc: PlantDesc, GenusDesc, SelfDesc               

                //if (searchString != null)
                //{
                //    pageNumber = 1;
                //}
                //else
                //{
                //    searchString = currentFilter;
                //}

                //ViewBag.CurrentFilter = searchString;

                //var listItem = from item in await repository.GetPlantsAsync() select item;
                //if (!String.IsNullOrEmpty(searchString))
                //{
                //    listItem = listItem.Where(item => 
                //        item.family_common_name.Contains(searchString) ||
                //        item.slug.Contains(searchString) ||
                //        item.scientific_name.Contains(searchString) ||
                //        item.year.Contains(searchString) ||
                //        item.bibliography.Contains(searchString) ||
                //        item.author.Contains(searchString) ||
                //        item.status.Contains(searchString) ||
                //        item.rank.Contains(searchString) ||
                //        item.family_common_name.Contains(searchString) ||
                //        item.image_url.Contains(searchString) ||
                //        item.synonyms.Contains(searchString) ||
                //        item.genus.Contains(searchString) ||
                //        item.family.Contains(searchString)
                //        //LinksDesc: PlantDesc, GenusDesc, SelfDesc               
                //    );
                //}

                //switch (sortOrder)
                //{
                //    case "CommonNameDesc":
                //        listItem = listItem.OrderByDescending(item => item.common_name);
                //        break;
                //    case "SlugDesc":
                //        listItem = listItem.OrderByDescending(item => item.slug);
                //        break;
                //    case "ScientificNameDesc":
                //        listItem = listItem.OrderByDescending(item => item.scientific_name);
                //        break;
                //    case "YearDesc":
                //        listItem = listItem.OrderByDescending(item => item.year);
                //        break;
                //    case "BibliographyDesc":
                //        listItem = listItem.OrderByDescending(item => item.bibliography);
                //        break;
                //    case "AuthorDesc":
                //        listItem = listItem.OrderByDescending(item => item.author);
                //        break;
                //    case "StatusDesc":
                //        listItem = listItem.OrderByDescending(item => item.status);
                //        break;
                //    case "RankDesc":
                //        listItem = listItem.OrderByDescending(item => item.rank);
                //        break;
                //    case "FamilyCommonNameDesc":
                //        listItem = listItem.OrderByDescending(item => item.family_common_name);
                //        break;
                //    case "GenusIdDesc":
                //        listItem = listItem.OrderByDescending(item => item.genus_id);
                //        break;
                //    case "ImageUrlDesc":
                //        listItem = listItem.OrderByDescending(item => item.image_url);
                //        break;
                //    case "SynonymsDesc":
                //        listItem = listItem.OrderByDescending(item => item.synonyms);
                //        break;
                //    case "GenusDesc":
                //        listItem = listItem.OrderByDescending(item => item.genus);
                //        break;
                //    case "FamilyDesc":
                //        listItem = listItem.OrderByDescending(item => item.family);
                //        break;
                //    case "PlantIdDesc":
                //        listItem = listItem.OrderByDescending(item => item.plant_id);
                //        break;
                //    default:
                //        listItem = listItem.OrderBy(item => item.id);
                //        break;
                //LinksDesc: PlantDesc, GenusDesc, SelfDesc
                //}
                int pageSize = 5;
                return View(Pagination<apiData>.Create(/*listItem*/x.data.ToPagedList(pageNumber ?? 1, pageSize), (pageNumber ?? 1), (pageSize)));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
