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

        public override Task<int> CreateEntity(Crew newEntity)
        {
            return base.CreateEntity(newEntity);
        }

        public override Task<bool> DeleteEntity(int id)
        {
            return base.DeleteEntity(id);
        }

        public override Task<List<Crew>> GetEntities()
        {
            return base.GetEntities();
        }

        public override Task<Crew> GetEntity(int id)
        {
            return base.GetEntity(id);
        }

        public override Task<bool> UpdateEntity(int id, Crew updatedEntity)
        {
            return base.UpdateEntity(id, updatedEntity);
        }

    }
}
