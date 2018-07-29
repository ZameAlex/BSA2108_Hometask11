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
        public DepartureService(ApiService service, string endpoint) : base(service, endpoint)
        { }

        public override int CreateEntity (Departure newEntity)
        {
            return base.CreateEntity(newEntity);
        }

        public override bool DeleteEntity (int id)
        {
            return base.DeleteEntity (id);
        }

        public override List<Departure> GetEntities ()
        {
            return base.GetEntities ();
        }

        public override Departure GetEntity (int id)
        {
            return base.GetEntity (id);
        }

        public override bool UpdateEntity (int id, Departure updatedEntity)
        {
            return base.UpdateEntity(id, updatedEntity);
        }

    }
}
