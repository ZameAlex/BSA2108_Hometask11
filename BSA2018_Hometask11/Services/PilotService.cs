using BSA2018_Hometask11.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSA2018_Hometask11.Services
{
    public class PilotService : AbstractService<Pilot>
    {
        public PilotService(ApiService service) : base(service, "pilots")
        { }

        public override Task<int> CreateEntity (Pilot newEntity)
        {
            return base.CreateEntity(newEntity);
        }

        public override Task<bool> DeleteEntity (int id)
        {
            return base.DeleteEntity (id);
        }

        public override Task<List<Pilot>> GetEntities ()
        {
            return base.GetEntities ();
        }

        public override Task<Pilot> GetEntity (int id)
        {
            return base.GetEntity (id);
        }

        public override Task<bool> UpdateEntity (int id, Pilot updatedEntity)
        {
            return base.UpdateEntity(id, updatedEntity);
        }


    }
}
