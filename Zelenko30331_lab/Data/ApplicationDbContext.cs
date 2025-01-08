using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Zelenko30331_lab.Domain.Entities;

namespace Zelenko30331_lab.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Zelenko30331_lab.Domain.Entities.Dish> Dish { get; set; } = default!;
    }
}
