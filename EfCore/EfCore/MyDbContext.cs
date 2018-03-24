using Microsoft.EntityFrameworkCore;

namespace EfCore
{
    public class MyDbContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=SeaOfLove; Database=EfCoreDB; Trusted_Connection=true;");
        }
    }
}