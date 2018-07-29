using BSA2018_Hometask11.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSA2018_Hometask11.Services
{
    public class StewardessService : AbstractService
    {
        public StewardessService(ApiService service, string endpoint) : base(service, endpoint)
        { }

        public override int CreateEntity<Stewardess>(Stewardess newEntity)
        {
            return base.CreateEntity(newEntity);
        }

        public override bool DeleteEntity<Stewardess>(int id)
        {
            return base.DeleteEntity<Stewardess>(id);
        }

        public override List<Stewardess> GetEntities<Stewardess>()
        {
            return base.GetEntities<Stewardess>();
        }

        public override Stewardess GetEntity<Stewardess>(int id)
        {
            return base.GetEntity<Stewardess>(id);
        }

        public override bool UpdateEntity<Stewardess>(int id, Stewardess updatedEntity)
        {
            return base.UpdateEntity(id, updatedEntity);
        }

    }
}
