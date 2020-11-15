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
        //public PagedList.IPagedList<Trefle> TrefleModels { get; set; }

        TrefleRepository repository;

        public TrefleViewModel(TrefleRepository _repository)
        {
            this.repository = _repository;
        }
    }

    // API DATA MODEL //

    public class Trefle
    {
        public List<Species> data { get; set; }
        public Trefle()
        {
            data = new List<Species>();
        }
    }
    public class Species
    {
        [Key]
        public int id { get; set; }
        public string common_name { get; set; }
        public string slug { get; set; }
        public string scientific_name { get; set; }
        public string year { get; set; } //The first publication year of a valid name of this species.
        public string bibliography { get; set; } //The first publication of a valid name of this species.
        public string author { get; set; } // 	The author(s) of the first publication of a valid name of this species.
        public string status { get; set; } // The acceptance status of this species by IPNI, can be: accepted and unknown.
        public string rank { get; set; } // The taxonomic rank of the species, can be: species, ssp, var, form, hybrid, and subvar.
        public string family_common_name { get; set; }
        public int genus_id { get; set; }
        public string image_url { get; set; }
        public string duration { get; set; }
        public string edible_part { get; set; }
        public bool edible { get; set; }
        public bool vegetable { get; set; }
        public string observation { get; set; }
        public List<string> common_names { get; set; }
        public List<string> distribution { get; set; }
        public List<string> synonyms { get; set; }
        public List<string> sources { get; set; }
        public string genus { get; set; }
        public string family { get; set; }
        public int plant_id { get; set; }

        public Links links { get; set; }
        public Images images { get; set; }
        public Distributions distributions { get; set; }
        public Flower flower { get; set; }
        public Foliage foliage { get; set; }
        public Fruit_or_seed fruit_or_seed { get; set; }
        public Specifications specifications { get; set; }
        public Growth growth { get; set; }
        //public SynonymsList synonyms { get; set; }
        //public Sources sources { get; set; }
    }

    public class Links
    {
        public string self { get; set; }
        public string plant { get; set; }
        public string genus { get; set; }
    }

    public class Images
    {
        public List<string> flower { get; set; }
        public List<string> leaf { get; set; }
        public List<string> habit { get; set; }
        public List<string> fruit { get; set; }
        public List<string> bark { get; set; }
        public List<string> other { get; set; }
    }

    public class Distributions
    {
        public List<string> native { get; set; }
        public List<string> introduced { get; set; }
        public List<string> doubtful { get; set; }
        public List<string> absent { get; set; }
        public List<string> extinct { get; set; }
    }

    public class Flower
    {
        public List<string> color { get; set; }
        public List<string> conspicuous { get; set; }
    }

    public class Foliage
    {
        public string texture { get; set; }
        public List<string> color { get; set; }
        public bool leaf_retention { get; set; }
    }

    public class Fruit_or_seed
    {
        public bool conspicuous { get; set; }
        public string color { get; set; }
        public string shape { get; set; }
        public bool seed_persistence { get; set; }
    }

    public class Specifications
    {
        public string type { get; set; }
        public string form { get; set; }
        public string growth_habit { get; set; }
        public string growth_rate { get; set; }
        public List<string> average_height { get; set; }
        public List<string> maximum_height { get; set; }
        public string nitrogen_fixation { get; set; }
        public string shape_and_orientation { get; set; }
        public string toxicity { get; set; }
    }

    public class Growth
    {
        public int days_to_harvest { get; set; }
        public string description { get; set; }
        public string sowing { get; set; }
        public int ph_maximum { get; set; }
        public int ph_minimum { get; set; }
        public int light { get; set; }
        public int atmospheric_humidity { get; set; }
        public List<string> growth_months { get; set; }
        public List<string> bloom_months { get; set; }
        public List<string> fruit_months { get; set; }
        public List<string> row_spacing { get; set; }
        public List<string> spread { get; set; }
        public List<string> minimum_precipitation { get; set; }
        public List<string> maximum_precipitation { get; set; }
        public List<string> minimum_root_depth { get; set; }
        public List<string> minimum_temperature { get; set; }
        public List<string> maximum_temperature { get; set; }
        public int soil_nutriments { get; set; }
        public int soil_salinity { get; set; }
        public int soil_texture { get; set; }
        public int soil_humidity { get; set; }
    }

    public class SynonymsList
    {
        public string id { get; set; }
        public string name { get; set; }
        public string author { get; set; }
    }

    public class Sources
    {
        public string id { get; set; }
        public string name { get; set; }
        public string citation { get; set; }
        public string url { get; set; }
        public string last_update { get; set; }
    }
}