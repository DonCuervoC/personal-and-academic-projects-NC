using FilmsWebCore5.Models;
using FilmsWebCore5.Repository.IRepository;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FilmsWebCore5.Repository
{
    public class AccountRepository : Repository<UserM>, IAccountRepository
    {
        // Dependency Injection
        private readonly IHttpClientFactory _httpClientFactory;

        public AccountRepository(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<UserM> LoginAsync(string url, UserM itemCreate)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, url); // send data to server
            if (itemCreate != null)
            {
                request.Content = new StringContent(
                    JsonConvert.SerializeObject(itemCreate), Encoding.UTF8, "application/json"
                    );
            }
            else
            {
                return new UserM();
            }

            var client = _httpClientFactory.CreateClient();

            HttpResponseMessage response = await client.SendAsync(request);
            // Validate if get and return data
            // if 204 OK(GET)
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var jsonString = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<UserM>(jsonString);
            }
            else
            {
                return new UserM();
            }
        }

        public async Task<bool> RegisterAsync(string url, UserM itemCreate)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, url); // send data to server
            if (itemCreate != null)
            {
                request.Content = new StringContent(
                    JsonConvert.SerializeObject(itemCreate), Encoding.UTF8, "application/json"
                    );
            }
            else
            {
                return false;
            }

            var client = _httpClientFactory.CreateClient();

            HttpResponseMessage response = await client.SendAsync(request);
            // Validate if get and return data
            // if 204 OK(GET)
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
