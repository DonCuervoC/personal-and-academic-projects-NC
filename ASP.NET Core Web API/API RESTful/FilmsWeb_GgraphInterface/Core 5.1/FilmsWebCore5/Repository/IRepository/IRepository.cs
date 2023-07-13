using System.Collections;
using System.Threading.Tasks;

namespace FilmsWebCore5.Repository.IRepository
{
    // Generic class ( T is a class generic)
    public interface IRepository<T> where T : class
    {
        //list 
        Task<IEnumerable> GetAllAsync(string url);
        //Method to filter films in a category
        Task<IEnumerable> GetFilmsInCategoryAsync(string url, int categoryID);
        //Method to find by name
        Task<IEnumerable> Find(string url, string name);
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
