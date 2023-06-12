using ApiFilms.Data;
using ApiFilms.Models;
using ApiFilms.Respository.IRepository;

namespace ApiFilms.Respository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _db;

        public CategoryRepository(ApplicationDbContext _db)
        {
            this._db = _db;
        }

        public bool UpdateCategory(Category category)
        {
            category.DateCreation = DateTime.Now;
            _db.Category.Update(category);
            return Save();
        }

        public bool CreateCategory(Category category)
        {
            category.DateCreation = DateTime.Now;
            _db.Category.Add(category);
            return Save();
        }

        public bool DeleteCategory(Category category)
        {
            _db.Category.Remove(category);
            return Save();
        }

        public bool ExistCategory(string name)
        {
            bool value = _db.Category.Any(x => x.Name.ToLower().Trim() == name.ToLower().Trim());
            return value;
        }

        public bool ExistCategory(int id)
        {
            return _db.Category.Any(x => x.Id == id);
        }

        public Category GetCategory(int idCategory)
        {
            return _db.Category.FirstOrDefault(x => x.Id == idCategory);
        }

        public ICollection<Category> GetCaterories()
        {
            return _db.Category.OrderBy(c => c.Name).ToList();
        }

        public bool Save()
        {
            return _db.SaveChanges() >= 0 ? true : false;
        }


    }
}
