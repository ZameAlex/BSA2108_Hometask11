using BSA2018_Hometask11.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSA2018_Hometask11.Services
{
    public class PilotService : AbstractService
    {
        public PilotService(ApiService service, string endpoint) : base(service, endpoint)
        { }

        public override int CreateEntity<Pilot>(Pilot newEntity)
        {
            return base.CreateEntity(newEntity);
        }

        public override bool DeleteEntity<Pilot>(int id)
        {
            return base.DeleteEntity<Pilot>(id);
        }

        public override List<Pilot> GetEntities<Pilot>()
        {
            return base.GetEntities<Pilot>();
        }

        public override Pilot GetEntity<Pilot>(int id)
        {
            return base.GetEntity<Pilot>(id);
        }

        public override bool UpdateEntity<Pilot>(int id, Pilot updatedEntity)
        {
            return base.UpdateEntity(id, updatedEntity);
        }


    }
}
