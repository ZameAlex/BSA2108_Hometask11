using BSA2018_Hometask11.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSA2018_Hometask11.Services
{
    public class PlaneService : AbstractService<Plane>
    {
        public PlaneService(ApiService service) : base(service, "planes")
        { }

        public override Task<int> CreateEntity (Plane newEntity)
        {
            return base.CreateEntity(newEntity);
        }

        public override Task<bool> DeleteEntity (int id)
        {
            return base.DeleteEntity (id);
        }

        public override Task<List<Plane>> GetEntities ()
        {
            return base.GetEntities ();
        }

        public override Task<Plane> GetEntity (int id)
        {
            return base.GetEntity (id);
        }

        public override Task<bool> UpdateEntity (int id, Plane updatedEntity)
        {
            return base.UpdateEntity(id, updatedEntity);
        }

    }
}
