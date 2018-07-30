using BSA2018_Hometask11.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSA2018_Hometask11.Services
{
    public class CrewService : AbstractService<Crew>
    {
        public CrewService(ApiService service) : base(service, "crew")
        { }

        public override int CreateEntity(Crew newEntity)
        {
            return base.CreateEntity(newEntity);
        }

        public override bool DeleteEntity(int id)
        {
            return base.DeleteEntity(id);
        }

        public override List<Crew> GetEntities()
        {
            return base.GetEntities();
        }

        public override Crew GetEntity(int id)
        {
            return base.GetEntity(id);
        }

        public override bool UpdateEntity(int id, Crew updatedEntity)
        {
            return base.UpdateEntity(id, updatedEntity);
        }

    }
}
