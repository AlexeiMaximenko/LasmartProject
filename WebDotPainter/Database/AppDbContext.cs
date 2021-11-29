using Microsoft.EntityFrameworkCore;
using WebDotPainter.Classes;
using WebDotPainter.Entity;

namespace WebDotPainter.Database
{
    public class AppDbContext : DbContext
    {
        public DbSet<Circle> Circle { get; set; }
        public DbSet<CircleComment> CircleComments { get; set; }

        public AppDbContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("WebDotPainterDB");
        }

    }
}
