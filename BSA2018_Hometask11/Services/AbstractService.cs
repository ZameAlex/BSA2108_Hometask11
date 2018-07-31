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

        public virtual async Task<List<T>> GetEntities() 
        {
            return await service.GetCollection<T>(endpoint);
        }

        public virtual async Task<T> GetEntity(int id)
        {
            return await service.GetItemByID<T>(endpoint, id);
        }

        public virtual async Task<int> CreateEntity(T newEntity)
        {

            var result = await service.AddItem(endpoint, newEntity);
            return result;
        }

        public virtual async Task<bool> DeleteEntity(int id) 
        {
            var result = await service.DeleteItem<T>(endpoint, id);
            return result;
        }

        public virtual async Task<bool> UpdateEntity(int id, T updatedEntity)
        {
            updatedEntity.Id = 0;
            var result = await service.ChangeItem(endpoint, updatedEntity, id);
            return result;

        }


    }
}
