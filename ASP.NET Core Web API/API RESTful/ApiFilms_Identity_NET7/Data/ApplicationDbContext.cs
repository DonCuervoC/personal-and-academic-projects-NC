using ApiFilms.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ApiFilms.Data
{
    // Inherit from the IdentityDbContext class and the Model AppUser
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        // Create AppUser with all the fields and detect identity when the migration is done
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        // ADD models here
        public DbSet<Category> Category { get; set; }
        public DbSet<Film> Film { get; set; }
        public DbSet<User> User { get; set; }

        // Model for Identity
        public DbSet<AppUser> AppUser { get; set; }
    }
}
