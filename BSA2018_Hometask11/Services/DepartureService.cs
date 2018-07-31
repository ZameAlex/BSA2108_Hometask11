using BSA2018_Hometask11.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSA2018_Hometask11.Services
{
    public class DepartureService : AbstractService<Departure>
    {
        public DepartureService(ApiService service) : base(service, "departures")
        { }

        public override Task<int> CreateEntity (Departure newEntity)
        {
            return base.CreateEntity(newEntity);
        }

        public override Task<bool> DeleteEntity (int id)
        {
            return base.DeleteEntity (id);
        }

        public override Task<List<Departure>> GetEntities ()
        {
            return base.GetEntities ();
        }

        public override Task<Departure> GetEntity (int id)
        {
            return base.GetEntity (id);
        }

        public override Task<bool> UpdateEntity (int id, Departure updatedEntity)
        {
            return base.UpdateEntity(id, updatedEntity);
        }

    }
}
