using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MobilePoint.Data
{
    public class MobilePointDbContext : IdentityDbContext<User>
    {
        public MobilePointDbContext(DbContextOptions<MobilePointDbContext> options)
            : base(options)
        {
        }
        public DbSet<Phone> Phones { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<BrandModel> BrandModels { get; set; }
    }
}