using Microsoft.EntityFrameworkCore;
using RealtorCAify.Models;

namespace RealtorCAify.Data
{
    public class RealtorCAifyDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.EnableSensitiveDataLogging();
            optionsBuilder.UseSqlite("Data Source=RealtorCAify.db");
            
        }
        
        public DbSet<ApiTransaction> ApiTransactions { get; set; }
        public DbSet<Listing> Listings { get; set; }
        
    }
}