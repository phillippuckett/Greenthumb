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
        public List<apiData> data { get; set; } = new List<apiData>();
        public virtual apiData GetPlantObject(int id)
        {
            return this.data.FirstOrDefault(x => x.id == id);
        }

        public virtual void AddPlants(List<apiData> apiDatas)
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

        public override void AddPlants(List<apiData> apiDatas)
        {
            base.AddPlants(apiDatas);
            Session.SetJson("Flora", this);
        }
    }
}
