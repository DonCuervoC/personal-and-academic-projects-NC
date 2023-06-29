using FilmsWebCore5.Models;
using FilmsWebCore5.Repository.IRepository;
using System.Net.Http;

namespace FilmsWebCore5.Repository
{
    public class FilmRepository : Repository<Film>, IFilmRepository
    {
        // Dependency Injection
        private readonly IHttpClientFactory _httpClientFactory;

        public FilmRepository(IHttpClientFactory httpClientFactory) : base(httpClientFactory) 
        {
            _httpClientFactory = httpClientFactory;
        }
    }
}
