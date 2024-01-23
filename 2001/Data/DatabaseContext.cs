
using Microsoft.EntityFrameworkCore;
using _2001.Models;

namespace _2001.Data
{


    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> option) : base(option)
        {
        }

        public DbSet<Users> CW2Users { get; set; }
        public DbSet<Trail> CW2Trail { get; set; }
        public DbSet<Filters> CW2Filters { get; set; }
        public DbSet<Archive> CW2Archive { get; set; }
        public DbSet<Administrator> CW2Administrator { get; set; }

    }
}
