using BSA2018_Hometask11.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSA2018_Hometask11.Services
{
    public class PlaneTypeService : AbstractService<PlaneType>
    {
        public PlaneTypeService(ApiService service) : base(service, "types")
        { }

        public override Task<int> CreateEntity (PlaneType newEntity)
        {
            return base.CreateEntity(newEntity);
        }

        public override Task<bool> DeleteEntity (int id)
        {
            return base.DeleteEntity (id);
        }

        public override Task<List<PlaneType>> GetEntities ()
        {
            return base.GetEntities ();
        }

        public override Task<PlaneType> GetEntity (int id)
        {
            return base.GetEntity (id);
        }

        public override Task<bool> UpdateEntity (int id, PlaneType updatedEntity)
        {
            return base.UpdateEntity(id, updatedEntity);
        }

    }
}
