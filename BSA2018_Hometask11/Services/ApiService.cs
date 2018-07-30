using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BSA2018_Hometask11.Services
{
    public class ApiService
    {

        Newtonsoft.Json.JsonSerializerSettings settings = new Newtonsoft.Json.JsonSerializerSettings();
        const string Base_URL = "http://localhost:51664/v1/api/";

        private static ApiService instance=null;

        public static ApiService GetInstance()
        {
            if (instance == null)
                instance = new ApiService();
            return instance;
        }

        private  ApiService()
        {
            settings.DateFormatString = "YYYY-MM-DDTHH:mm:ss.FFFZ";
        }
        public async Task<List<T>> GetCollection<T>(string endpoint)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(Base_URL);
                var result = await client.GetStringAsync(client.BaseAddress + endpoint);
                return Newtonsoft.Json.JsonConvert.DeserializeObject<List<T>>(result);
            }
        }

        public async Task<T> GetItemByID<T>(string endpoint, int id)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(Base_URL);
                var result = await client.GetStringAsync(client.BaseAddress + endpoint + $"/{id}");
                return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(result);
            }
        }

        public async Task<int> AddItem<T>(string endpoint, T item)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(Base_URL);
                var content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(item), Encoding.UTF8, "application/json");
                var result = await client.PostAsync(client.BaseAddress + endpoint, content);
                if(result.IsSuccessStatusCode)
                    return 1;
                return -1;
            }
        }

        public async Task<bool> ChangeItem<T>(string endpoint, T item, int id)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(Base_URL);
                var content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(item), Encoding.UTF8, "application/json");
                var result = await client.PutAsync(client.BaseAddress + endpoint + $"/{id}", content);
                return result.IsSuccessStatusCode;
            }
        }

        public async Task<bool> DeleteItem<T>(string endpoint, int id)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(Base_URL);
                var result = await client.DeleteAsync(client.BaseAddress + endpoint + $"/{id}");
                return result.StatusCode == System.Net.HttpStatusCode.NoContent;
            }
        }
    }
}
