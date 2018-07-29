using BSA2018_Hometask11.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSA2018_Hometask11.Services
{
    public class PlaneService : AbstractService
    {
        public PlaneService(ApiService service, string endpoint) : base(service, endpoint)
        { }

        public override int CreateEntity<Plane>(Plane newEntity)
        {
            return base.CreateEntity(newEntity);
        }

        public override bool DeleteEntity<Plane>(int id)
        {
            return base.DeleteEntity<Plane>(id);
        }

        public override List<Plane> GetEntities<Plane>()
        {
            return base.GetEntities<Plane>();
        }

        public override Plane GetEntity<Plane>(int id)
        {
            return base.GetEntity<Plane>(id);
        }

        public override bool UpdateEntity<Plane>(int id, Plane updatedEntity)
        {
            return base.UpdateEntity(id, updatedEntity);
        }

    }
}
