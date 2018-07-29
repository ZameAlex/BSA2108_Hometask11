using BSA2018_Hometask11.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSA2018_Hometask11.Services
{
    public abstract class AbstractService<T> where T : Entity
    {
        protected readonly ApiService service;
        protected readonly string endpoint;

        protected AbstractService(ApiService service, string endpoint)
        {
            this.service = service;
            this.endpoint = endpoint;
        }

        public virtual List<T> GetEntities() 
        {
            return service.GetCollection<T>(endpoint);
        }

        public virtual T GetEntity(int id)
        {
            return service.GetItemByID<T>(endpoint, id);
        }

        public virtual int CreateEntity(T newEntity)
        {

            var result = service.AddItem(endpoint, newEntity);
            return result;
        }

        public virtual bool DeleteEntity(int id) 
        {
            var result = service.DeleteItem<T>(endpoint, id);
            return result;
        }

        public virtual bool UpdateEntity(int id, T updatedEntity)
        {
            var result = service.ChangeItem(endpoint, updatedEntity, id);
            return result;

        }


    }
}
