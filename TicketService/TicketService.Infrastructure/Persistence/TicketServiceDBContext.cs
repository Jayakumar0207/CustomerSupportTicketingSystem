using Microsoft.EntityFrameworkCore;
using TicketService.Domain.Entities;

namespace TicketService.Infrastructure
{
    public class TicketServiceDBContext : DbContext
    {
        public TicketServiceDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions) { }

        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ticket>()
            .Property(t => t.TicketId)
            .UseIdentityColumn(seed: 1101, increment: 1);

            modelBuilder.Entity<Comment>()
            .Property(c => c.CommentID)
            .UseIdentityColumn(seed: 2101, increment: 1);

            modelBuilder.Entity<Ticket>()
            .Property(t => t.Status)
            .HasConversion<string>();

            modelBuilder.Entity<Comment>()
            .HasOne(o => o.Ticket)
            .WithMany(o => o.Comments)
            .HasForeignKey(o => o.TicketID)
            .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Ticket>().Property(p => p.CreatedAt)
                .HasDefaultValueSql("GETDATE()")
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Ticket>().Property(p => p.UpdatedAt)
                .HasDefaultValueSql("GETDATE()")
                .ValueGeneratedOnAddOrUpdate();

            modelBuilder.Entity<Comment>().Property(p => p.CreatedAt)
                .HasDefaultValueSql("GETDATE()")
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Comment>().Property(p => p.UpdatedAt)
                .ValueGeneratedOnAddOrUpdate();
        }
        public override int SaveChanges()
        {
            UpdateTimestamps();
            return base.SaveChanges();
        }
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            UpdateTimestamps();
            return await base.SaveChangesAsync(cancellationToken);
        }
        private void UpdateTimestamps()
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is Ticket &&
                            (e.State == EntityState.Added || e.State == EntityState.Modified));

            foreach (var entry in entries)
            {
                var entity = (Ticket)entry.Entity;

                if (entry.State == EntityState.Added)
                {
                    entity.CreatedAt = DateTime.UtcNow;
                    entity.UpdatedAt = DateTime.UtcNow;
                }
                else if (entry.State == EntityState.Modified)
                {
                    // Prevent changing CreatedAt on update
                    entry.Property(nameof(entity.CreatedAt)).IsModified = false;
                    entity.UpdatedAt = DateTime.UtcNow;
                }
            }
        }
    }
}
