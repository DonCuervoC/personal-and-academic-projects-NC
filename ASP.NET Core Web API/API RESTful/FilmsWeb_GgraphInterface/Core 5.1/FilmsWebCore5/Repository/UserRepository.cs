using FilmsWebCore5.Models;
using FilmsWebCore5.Repository.IRepository;
using System.Net.Http;

namespace FilmsWebCore5.Repository
{
    public class UserRepository : Repository<UserU>, IUserRepository
    {
        // Dependency Injection
        private readonly IHttpClientFactory _httpClientFactory;

        public UserRepository(IHttpClientFactory httpClientFactory) : base(httpClientFactory) 
        {
            _httpClientFactory = httpClientFactory;
        }
    }
}
