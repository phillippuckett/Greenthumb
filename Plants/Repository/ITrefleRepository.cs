using Plants.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Plants.Repository
{
    public interface ITrefleRepository
    {
        public Task<List<Species>> GetPlantsAsync();
    }
}