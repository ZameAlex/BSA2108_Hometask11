using BSA2018_Hometask11.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSA2018_Hometask11.Services
{
    public class StewardessService : AbstractService<Stewardess>
    {
        public StewardessService(ApiService service) : base(service, "stewardess")
        { }

        public override Task<int> CreateEntity (Stewardess newEntity)
        {
            return base.CreateEntity(newEntity);
        }

        public override Task<bool> DeleteEntity (int id)
        {
            return base.DeleteEntity (id);
        }

        public override Task<List<Stewardess>> GetEntities ()
        {
            return base.GetEntities ();
        }

        public override Task<Stewardess> GetEntity (int id)
        {
            return base.GetEntity (id);
        }

        public override Task<bool> UpdateEntity (int id, Stewardess updatedEntity)
        {
            return base.UpdateEntity(id, updatedEntity);
        }

    }
}
