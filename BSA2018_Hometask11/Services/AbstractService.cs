using BSA2018_Hometask11.Models;
using System.Collections.Generic;

namespace BSA2018_Hometask11.Services
{
    public abstract class AbstractService
    {
        protected readonly ApiService service;
        protected readonly string endpoint;

        protected AbstractService(ApiService service, string endpoint)
        {
            this.service = service;
            this.endpoint = endpoint;
        }

        public virtual List<T> GetEntities<T>() where T : Entity
        {
            return service.GetCollection<T>(endpoint);
        }

        public virtual T GetEntity<T>(int id) where T : Entity
        {
            return service.GetItemByID<T>(endpoint, id);
        }

        public virtual int CreateEntity<T>(T newEntity) where T : Entity
        {

            var result = service.AddItem<T>(endpoint, newEntity);
            return result;
        }

        public virtual bool DeleteEntity<T>(int id) where T : Entity
        {
            var result = service.DeleteItem<T>(endpoint, id);
            return result;
        }

        public virtual bool UpdateEntity<T>(int id, T updatedEntity) where T : Entity
        {
            var result = service.ChangeItem<T>(endpoint, updatedEntity, id);
            return result;

        }


    }
}
