using FilmsWebCore5.Models;
using System.Threading.Tasks;

namespace FilmsWebCore5.Repository.IRepository
{

    public interface IAccountRepository : IRepository<UserM>
    {
      
        Task<UserM> LoginAsync(string url, UserM itemCreate);
        
        Task<bool> RegisterAsync(string url, UserM itemCreate);
    }
}
