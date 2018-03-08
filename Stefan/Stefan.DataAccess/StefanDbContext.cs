using Microsoft.EntityFrameworkCore;
using Stefan.DataAccess.Entities;

namespace Stefan.DataAccess
{
    public class StefanDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=D:\\Stefan.db;");
        }

        public DbSet<Manufacturer> Manufacturers { get; set; }
    }
}
