using Microsoft.EntityFrameworkCore;
using LoanManagementApi.Models;

namespace LoanManagementApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Loan> Loans { get; set; }
    }
}