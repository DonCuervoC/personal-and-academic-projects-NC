using ApiFilms.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiFilms.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        // ADD models here
        public DbSet<Category> Category { get; set; }
        public DbSet<Film> Film { get; set; }
    }
}
