using FilmsWebCore5.Models;
using FilmsWebCore5.Repository.IRepository;
using System.Net.Http;

namespace FilmsWebCore5.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        // Dependency Injection
        private readonly IHttpClientFactory _httpClientFactory;

        public CategoryRepository(IHttpClientFactory httpClientFactory) : base(httpClientFactory) 
        {
            _httpClientFactory = httpClientFactory;
        }


    }
}
