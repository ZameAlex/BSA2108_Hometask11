using BSA2018_Hometask11.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSA2018_Hometask11.Services
{
    public class DepartureService : AbstractService
    {
        public DepartureService(ApiService service, string endpoint) : base(service, endpoint)
        { }

        public override int CreateEntity<Departure>(Departure newEntity)
        {
            return base.CreateEntity(newEntity);
        }

        public override bool DeleteEntity<Departure>(int id)
        {
            return base.DeleteEntity<Departure>(id);
        }

        public override List<Departure> GetEntities<Departure>()
        {
            return base.GetEntities<Departure>();
        }

        public override Departure GetEntity<Departure>(int id)
        {
            return base.GetEntity<Departure>(id);
        }

        public override bool UpdateEntity<Departure>(int id, Departure updatedEntity)
        {
            return base.UpdateEntity(id, updatedEntity);
        }

    }
}
