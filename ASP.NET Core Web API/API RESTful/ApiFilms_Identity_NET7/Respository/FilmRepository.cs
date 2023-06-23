using ApiFilms.Data;
using ApiFilms.Models;
using ApiFilms.Respository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace ApiFilms.Respository
{
    public class FilmRepository : IFilmRepository
    {
        private readonly ApplicationDbContext _db;

        public FilmRepository(ApplicationDbContext _db)
        {
            this._db = _db;
        }

        public bool UpdateFilm(Film film)
        {
            film.CreationDate = DateTime.Now;
            _db.Film.Update(film);
            return Save();
        }

        public bool CreateFilm(Film film)
        {
            film.CreationDate = DateTime.Now;
            _db.Film.Add(film);
            return Save();
        }

        public bool DeleteFilm(Film film)
        {
            _db.Film.Remove(film);
            return Save();
        }

        public bool ExistFilm(string name)
        {
            bool value = _db.Film.Any(x => x.Name.ToLower().Trim() == name.ToLower().Trim());
            return value;
        }

        public bool ExistFilm(int id)
        {
            return _db.Film.Any(x => x.Id == id);
        }

        public Film GetFilm(int idFilm)
        { 
            return _db.Film.FirstOrDefault(x => x.Id == idFilm);
        }

        public ICollection<Film> GetFilms()
        {
            return _db.Film.OrderBy(c => c.Name).ToList();
        }

        public ICollection<Film> GetFilmsInCategory(int catId)
        {
            // Includ : It allows us to have related data between two tables.
            return _db.Film.Include(ca => ca.Category).Where(ca => ca.categoryId == catId).ToList();
        }

        public ICollection<Film> FindFilm(string name)
        {         
            IQueryable<Film> query = _db.Film; // nos permite realizar consultas sobre una entidad

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where( e => e.Name.Contains(name) || e.Description.Contains(name));
            }
            return query.ToList();  
        }

        public bool Save()
        {
            return _db.SaveChanges() >= 0 ? true : false;
        }


    }
}
