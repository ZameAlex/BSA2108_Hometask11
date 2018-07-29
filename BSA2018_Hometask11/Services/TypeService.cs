using BSA2018_Hometask11.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSA2018_Hometask11.Services
{
    public class PlaneTypeService : AbstractService
    {
        public PlaneTypeService(ApiService service, string endpoint) : base(service, endpoint)
        { }

        public override int CreateEntity<PlaneType>(PlaneType newEntity)
        {
            return base.CreateEntity(newEntity);
        }

        public override bool DeleteEntity<PlaneType>(int id)
        {
            return base.DeleteEntity<PlaneType>(id);
        }

        public override List<PlaneType> GetEntities<PlaneType>()
        {
            return base.GetEntities<PlaneType>();
        }

        public override PlaneType GetEntity<PlaneType>(int id)
        {
            return base.GetEntity<PlaneType>(id);
        }

        public override bool UpdateEntity<PlaneType>(int id, PlaneType updatedEntity)
        {
            return base.UpdateEntity(id, updatedEntity);
        }

    }
}
