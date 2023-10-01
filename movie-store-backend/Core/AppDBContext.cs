using Microsoft.EntityFrameworkCore;
using movie_store_backend.Domain;

namespace movie_store_backend.Core
{
    public class AppDBContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "movieStore");
        }
    }
}
