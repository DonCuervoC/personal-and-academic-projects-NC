using ApiFilms.Models;

namespace ApiFilms.Respository.IRepository
{
    public interface IFilmRepository
    {
        // get films (return list)
        ICollection<Film> GetFilms();
        Film GetFilm(int idFilm);
        bool ExistFilm(string name);
        bool ExistFilm(int id);
        bool CreateFilm(Film film);
        bool UpdateFilm(Film film);
        bool DeleteFilm(Film film);
        // Methods to find Films in category and find by name
        ICollection<Film> GetFilmsInCategory(int catId);
        ICollection<Film> FindFilm(string name);

        bool Save();

    }
}
