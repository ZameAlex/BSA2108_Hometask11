using BSA2018_Hometask11.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSA2018_Hometask11.Services
{
    public class CrewService : AbstractService
    {
        public CrewService(ApiService service, string endpoint) : base(service, endpoint)
        { }

        public override int CreateEntity<Crew>(Crew newEntity)
        {
            return base.CreateEntity(newEntity);
        }

        public override bool DeleteEntity<Crew>(int id)
        {
            return base.DeleteEntity<Crew>(id);
        }

        public override List<Crew> GetEntities<Crew>()
        {
            return base.GetEntities<Crew>();
        }

        public override Crew GetEntity<Crew>(int id)
        {
            return base.GetEntity<Crew>(id);
        }

        public override bool UpdateEntity<Crew>(int id, Crew updatedEntity)
        {
            return base.UpdateEntity(id, updatedEntity);
        }

    }
}
