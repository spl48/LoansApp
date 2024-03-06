using System.Reflection.Emit;
using LoansApp.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace LoansApp.Server.Models
{
    public class ApplicationDbContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            const string priceDecimalType = "decimal(18,2)";
            const string tablePrefix = "App";

            builder.Entity<Customer>().Property(c => c.Title).IsRequired().HasMaxLength(6);
            builder.Entity<Customer>().Property(c => c.FirstName).IsRequired().HasMaxLength(100);
            builder.Entity<Customer>().Property(c => c.LastName).IsRequired().HasMaxLength(100);
            builder.Entity<Customer>().Property(c => c.Address).HasMaxLength(100);
            builder.Entity<Customer>().Property(c => c.Email).HasMaxLength(100);
            builder.Entity<Customer>().Property(c => c.MobileNumber).IsUnicode(false).HasMaxLength(30);
            builder.Entity<Customer>().Property(c => c.IsHomeOwner).HasColumnType("bit");
            builder.Entity<Customer>().Property(c => c.AnnualIncome).HasColumnType(priceDecimalType);
            builder.Entity<Customer>().ToTable($"{tablePrefix}{nameof(Customers)}");



        }

        public override int SaveChanges()
        {
            AddAuditInfo();
            return base.SaveChanges();
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            AddAuditInfo();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            AddAuditInfo();
            return base.SaveChangesAsync(cancellationToken);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess,
            CancellationToken cancellationToken = default)
        {
            AddAuditInfo();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        private void AddAuditInfo()
        {
            var modifiedEntries = ChangeTracker.Entries()
                .Where(x => x.Entity is IAuditableEntity &&
                           (x.State == EntityState.Added || x.State == EntityState.Modified));

            foreach (var entry in modifiedEntries)
            {
                var entity = (IAuditableEntity)entry.Entity;
                var now = DateTime.UtcNow;

                if (entry.State == EntityState.Added)
                {
                    entity.CreatedDate = now;
                }
                else
                {
                    base.Entry(entity).Property(x => x.CreatedDate).IsModified = false;
                }

                entity.UpdatedDate = now;
            }
        }
    }
}
