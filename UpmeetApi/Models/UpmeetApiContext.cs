using Microsoft.EntityFrameworkCore;

namespace UpmeetApi.Models
{
    public class UpmeetApiContext: DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Favorite> Favorites { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=UpmeetDb;Trusted_Connection=True;");
        }

    }
}
