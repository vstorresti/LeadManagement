using LeadManagement.Domain.Core;
using LeadManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LeadManagement.Infrastructure.Repositories.Contexts
{
    public class LeadDbContext : DbContext
    {
        public DbSet<Lead> Leads { get; set; }
        public DbSet<LeadEventEntity> LeadEvents { get; set; }

        public LeadDbContext(DbContextOptions<LeadDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Lead>(entity =>
            {
                entity.ToTable("Leads");

                entity.OwnsOne(e => e.Contact, contact =>
                {
                    contact.Property(c => c.FirstName).HasColumnName("FirstName").HasMaxLength(100);
                    contact.Property(c => c.FullName).HasColumnName("FullName").HasMaxLength(200);
                    contact.Property(c => c.Phone).HasColumnName("Phone").HasMaxLength(15);
                    contact.Property(c => c.Email).HasColumnName("Email").HasMaxLength(100);
                });

                entity.Property(e => e.Suburb).HasColumnName("Suburb").HasMaxLength(100);
                entity.Property(e => e.Category).HasColumnName("Category").HasMaxLength(100);
                entity.Property(e => e.Description).HasColumnName("Description").HasMaxLength(500);
                entity.Property(e => e.Price).HasColumnName("Price").HasColumnType("decimal(18,2)");
                entity.Property(e => e.DateCreated).HasColumnName("DateCreated");
                entity.Property(e => e.Status).HasColumnName("Status").HasConversion<string>();
            });
        }
    }
}
