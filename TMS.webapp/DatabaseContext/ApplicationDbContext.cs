using Microsoft.EntityFrameworkCore;
using TMS.webapp.Models;

namespace TMS.webapp.DatabaseContext
{
    public class ApplicationDbContext(DbContextOptions options) : DbContext(options)
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
        public DbSet<TMS.webapp.Models.Teacher> Teacher { get; set; } = default!;
    }
}
