using DataModels.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataModels
{
    class DataContext : DbContext
    {
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Message> Messages { get; set; } = null!;
        public DbSet<Place> Places { get; set; } = null!;
        public DbSet<Event> Events { get; set; } = null!;

        public const string DataSource = @"C:\Data\data.db";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseSqlite($"Data source = {DataSource}");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Event>()
                .HasMany(e => e.Participants)
                .WithMany(u => u.ParticipantEvents)
                .UsingEntity(j => j.ToTable("ParticipantEvent"));

            modelBuilder.Entity<Event>()
                .HasMany(e => e.Moderators)
                .WithMany(u => u.ModeratorEvents)
                .UsingEntity(j => j.ToTable("ModeratorEvent"));

            modelBuilder.Entity<Event>()
                .HasMany(e => e.Organizers)
                .WithMany(u => u.OrganizerEvents)
                .UsingEntity(j => j.ToTable("OrganizerEvent"));

            modelBuilder.Entity<Event>()
                .HasMany(e => e.MustBeChangedUsers)
                .WithMany(u => u.MustBeChangedEvents)
                .UsingEntity(j => j.ToTable("MustBeChangedEvent"));

            modelBuilder.Entity<User>()
                .HasOne(u => u.Birthday)
                .WithMany(d => d.Users);

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().HasData(User.Admin);
            modelBuilder.Entity<User>().HasData(User.Guest);
        }
    }
}
