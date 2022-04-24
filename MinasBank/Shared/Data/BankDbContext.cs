using Microsoft.EntityFrameworkCore;
using MinasBank.Areas.Devs.Models;

namespace MinasBank.Shared.Data
{
    public class BankDbContext : DbContext
    {
        public BankDbContext(DbContextOptions<BankDbContext> options) : base(options)
        {
        }

        public DbSet<Dev> Devs { get; set; }
    }
}
