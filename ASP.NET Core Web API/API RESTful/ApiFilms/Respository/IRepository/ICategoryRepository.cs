using ApiFilms.Models;

namespace ApiFilms.Respository.IRepository
{
    public interface ICategoryRepository
    {
        // get caterogies
        ICollection<Category> GetCaterories();

        Category GetCategory(int idCategory);

        bool ExistCategory(string name);
        bool ExistCategory(int id);
        bool CreateCategory(Category category);
        bool UpdateCategory(Category category);
        bool DeleteCategory(Category category);
        bool Save();

    }
}
