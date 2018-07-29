using BSA2018_Hometask11.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSA2018_Hometask11.Services
{
    public class FlightService : AbstractService
    {
        public FlightService(ApiService service, string endpoint) : base(service, endpoint)
        { }

        public override int CreateEntity<Flight>(Flight newEntity)
        {
            return base.CreateEntity(newEntity);
        }

        public override bool DeleteEntity<Flight>(int id)
        {
            return base.DeleteEntity<Flight>(id);
        }

        public override List<Flight> GetEntities<Flight>()
        {
            return base.GetEntities<Flight>();
        }

        public override Flight GetEntity<Flight>(int id)
        {
            return base.GetEntity<Flight>(id);
        }

        public override bool UpdateEntity<Flight>(int id, Flight updatedEntity)
        {
            return base.UpdateEntity(id, updatedEntity);
        }

    }
}
