using Microsoft.EntityFrameworkCore;
using Plants.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Plants.Models
{
    // VIEW MODEL //
    public class TrefleViewModel
    {
        public PagedList.IPagedList<Trefle> TrefleModels { get; set; }

        TrefleRepository repository;

        public TrefleViewModel(TrefleRepository _repository)
        {
            this.repository = _repository;
        }
    }

    // API DATA MODEL //

    public class Trefle
    {
        public List<apiData> data { get; set; }
        public Trefle()
        {
            data = new List<apiData>();
        }
    }

    public class apiData
    {
        [Key]
        public int id { get; set; }
        public string common_name { get; set; }
        public string slug { get; set; }
        public string scientific_name { get; set; }
        public string year { get; set; }
        public string bibliography { get; set; }
        public string author { get; set; }
        public string status { get; set; }
        public string rank { get; set; }
        public string family_common_name { get; set; }
        public int genus_id { get; set; }
        public string image_url { get; set; }
        public List<string> synonyms { get; set; }
        public string genus { get; set; }
        public string family { get; set; }
        public Links links { get; set; }
        public int plant_id { get; set; }
    }
    public class Links
    {
        public string self { get; set; }
        public string plant { get; set; }
        public string genus { get; set; }
    }
}
