using ATK_Business_API.Models;
using Microsoft.EntityFrameworkCore;

namespace ATK_Business_API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<BusinessLedger> BusinessLedger { get; set; }
    }
}
