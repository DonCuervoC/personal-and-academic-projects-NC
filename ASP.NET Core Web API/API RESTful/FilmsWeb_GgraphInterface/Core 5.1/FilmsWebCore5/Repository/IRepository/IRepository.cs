using System.Collections;
using System.Threading.Tasks;

namespace FilmsWebCore5.Repository.IRepository
{
    // Generic class ( T is a class generic)
    public interface IRepository<T> where T : class
    {
        //list 
        Task<IEnumerable> GetAllAsync(string url);
        //films, category etc...
        Task<T> GetAsync(string url, int Id);
        //Create category, films etc..
        Task<bool> CreateAsync(string url, T itemToCreate);
        //Update category, films etc..
        Task<bool> UpdateAsync(string url, T itemToUpdate);
        //Delete category, films etc..
        Task<bool> DeleteAsync(string url, int Id);
    }
}
