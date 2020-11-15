using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Plants.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace Plants.Models
{
    // PLANT //
    public class Plant
    {
        public List<Species> data { get; set; } = new List<Species>();
        public virtual Species GetPlantObject(int id)
        {
            return this.data.FirstOrDefault(x => x.id == id);
        }

        public virtual void AddPlants(List<Species> apiDatas)
        {
            this.data.AddRange(apiDatas);
        }
    }

    // SESSION //
    public class PlantSession : Plant
    {
        [JsonIgnore]
        public ISession Session { get; set; }

        public static Plant GetPlantList(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            PlantSession plant = session?.GetJson<PlantSession>("Flora") ?? new PlantSession();
            plant.Session = session;
            return plant;
        }

        public override void AddPlants(List<Species> apiDatas)
        {
            base.AddPlants(apiDatas);
            Session.SetJson("Flora", this);
        }
    }
}
