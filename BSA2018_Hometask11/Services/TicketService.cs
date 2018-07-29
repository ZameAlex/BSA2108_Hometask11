using BSA2018_Hometask11.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSA2018_Hometask11.Services
{
    public class TicketService : AbstractService
    {
        public TicketService(ApiService service, string endpoint) : base(service, endpoint)
        { }

        public override int CreateEntity<Ticket>(Ticket newEntity)
        {
            return base.CreateEntity(newEntity);
        }

        public override bool DeleteEntity<Ticket>(int id)
        {
            return base.DeleteEntity<Ticket>(id);
        }

        public override List<Ticket> GetEntities<Ticket>()
        {
            return base.GetEntities<Ticket>();
        }

        public override Ticket GetEntity<Ticket>(int id)
        {
            return base.GetEntity<Ticket>(id);
        }

        public override bool UpdateEntity<Ticket>(int id, Ticket updatedEntity)
        {
            return base.UpdateEntity(id, updatedEntity);
        }

    }
}
