using Microsoft.EntityFrameworkCore;
using Zelenko30331_lab.Domain.Entities;
using Zelenko30331_lab.API.Data;

namespace Zelenko30331_lab.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Category> Category { get; set; }
    }
}
