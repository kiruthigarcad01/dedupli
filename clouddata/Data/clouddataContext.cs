using Microsoft.EntityFrameworkCore;
using clouddata.Models;

namespace clouddata.Data
{
    public class clouddataContext : DbContext
    {
        public clouddataContext(DbContextOptions<clouddataContext> options)
            : base(options)
        {
        }

        public DbSet<DeduplicateViewModel> DeduplicateViewModel { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DeduplicateViewModel>().ToTable("DeduplicateViewModel");
        }
    }
}
