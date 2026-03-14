using Microsoft.EntityFrameworkCore;
using FinTrackPro.Models;

namespace FinTrackPro.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Account> Accounts { get; set; }
    }
}