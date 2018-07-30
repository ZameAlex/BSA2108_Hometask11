using BSA2018_Hometask11.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSA2018_Hometask11.Services
{
    public class FlightService : AbstractService<Flight>
    {
        public FlightService(ApiService service) : base(service, "flights")
        { }

        public override Task<int> CreateEntity (Flight newEntity)
        {
            return base.CreateEntity(newEntity);
        }

        public override Task<bool> DeleteEntity (int id)
        {
            return base.DeleteEntity (id);
        }

        public override Task<List<Flight>> GetEntities ()
        {
            return base.GetEntities ();
        }

        public override Task<Flight> GetEntity (int id)
        {
            return base.GetEntity (id);
        }

        public override Task<bool> UpdateEntity (int id, Flight updatedEntity)
        {
            return base.UpdateEntity(id, updatedEntity);
        }

    }
}
