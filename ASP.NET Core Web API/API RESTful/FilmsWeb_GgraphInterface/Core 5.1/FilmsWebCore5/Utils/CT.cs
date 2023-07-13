using System.Runtime.CompilerServices;

namespace FilmsWebCore5.Utils
{
    public static class CT  // Constants // it is static because it can be acceded from others places
    {
        public static string UrlBaseApi = "https://localhost:7153/";
        public static string RouteCategoriesApi = UrlBaseApi + "api/categories";
        public static string RouteFilmsApi = UrlBaseApi + "api/films";
        public static string RouteUsersApi = UrlBaseApi + "api/users";

        // Add more routes to find and filter films by category
        // https://localhost:7153/api/films/GetFilmsInCategory/1
        public static string RouteFilmsInCategoryApi = UrlBaseApi + "api/GetFilmsInCategory/";
        // https://localhost:7153/api/films/FindFilm?name=evil
        public static string RouteFilmsApiFind = UrlBaseApi + "api/films/FindFilm?name=";
    }
}
