using FilmsWebCore5.Repository.IRepository;
using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FilmsWebCore5.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        //Dependency injection, must impot IHttpClientFactory
        private readonly IHttpClientFactory _httpClientFactory;

        public Repository(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }


        public async Task<bool> UpdateAsync(string url, T itemToUpdate)
        {

            var req = new HttpRequestMessage(HttpMethod.Patch, url);

            if (itemToUpdate != null)
            {
                req.Content = new StringContent(
                    JsonConvert.SerializeObject(itemToUpdate), Encoding.UTF8, "application/json"
                    );
            }
            else
            {
                return false;
            }

            var client = _httpClientFactory.CreateClient();

            HttpResponseMessage response = await client.SendAsync(req);

            // Validate if updated and return bool
            // if 204 NotContent(Updated)
            if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
            {
                return true;
            }
            else { return false; }
        }



        public async Task<bool> DeleteAsync(string url, int Id)
        {
            // Concatenate url + Id to know what will be the source to delete.
            var req = new HttpRequestMessage(HttpMethod.Delete, url + "/" + Id);

            var monURL = url;

            var client = _httpClientFactory.CreateClient();

            HttpResponseMessage response = await client.SendAsync(req);

            // Validate if deleted and return bool
            // if 204 NotContent(Delete)
            if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
            {
                return true;
            }
            else { return false; }
        }


        public async Task<bool> CreateAsync(string url, T itemToCreate)
        {
            var req = new HttpRequestMessage(HttpMethod.Post, url);

            if (itemToCreate != null)
            {
                req.Content = new StringContent(
                    JsonConvert.SerializeObject(itemToCreate), Encoding.UTF8, "application/json"
                    );
            }
            else
            {
                return false;
            }

            var client = _httpClientFactory.CreateClient();

            HttpResponseMessage response = await client.SendAsync(req);

            // Validate if created and return bool
            // if 200 NotContent(Create)
            if (response.StatusCode == System.Net.HttpStatusCode.Created)
            {
                return true;
            }
            else { return false; }
        }

        public async Task<T> GetAsync(string url, int Id)
        {
            var request = url + "/"+Id;
            // Concatenate url + Id to know what will be the source to get.
            //var req = new HttpRequestMessage(HttpMethod.Get, url + Id);
            var req = new HttpRequestMessage(HttpMethod.Get, url + "/" + Id);

            var client = _httpClientFactory.CreateClient();

            HttpResponseMessage response = await client.SendAsync(req);

            // Validate if get and return data
            // if 204 OK(GET)
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var jsonString = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<T>(jsonString); // Because its a generic class
            }
            else { return null; }
        }


        public async Task<IEnumerable> GetAllAsync(string url)
        {
            // Concatenate url + Id to know what will be the source to get (LIST).
            var req = new HttpRequestMessage(HttpMethod.Get, url);

            var client = _httpClientFactory.CreateClient();

            HttpResponseMessage response = await client.SendAsync(req);

            // Validate if get and return data
            // if 204 OK(GET)
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IEnumerable<T>>(jsonString); // Because its a List (IEnumerable)
            }
            else { return null; }
        }





    }
}
