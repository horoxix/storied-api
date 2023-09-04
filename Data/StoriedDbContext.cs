using Data.Entities;

using Microsoft.EntityFrameworkCore;

namespace Data;

public class StoriedDbContext : DbContext
{
    public DbSet<Person> People { get; set; }
    public DbSet<Event> Events { get; set; }
    public DbSet<EventType> EventTypes { get; set; }
    public DbSet<Gender> Genders { get; set; }
    public DbSet<Location> Locations { get; set; }
    public DbSet<PersonVersion> PersonVersions { get; set; }

    public StoriedDbContext() { }
    public StoriedDbContext(DbContextOptions<StoriedDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Gender>()
            .HasData(new List<Gender>()
            {
                new Gender()
                {
                    Id = Guid.NewGuid(),
                    Name = "Male"
                },
                new Gender()
                {
                    Id = Guid.NewGuid(),
                    Name = "Female"
                },
                new Gender()
                {
                    Id = Guid.NewGuid(),
                    Name = "Non-binary"
                },
                new Gender()
                {
                    Id = Guid.NewGuid(),
                    Name = "Transgender"
                },
                new Gender()
                {
                    Id = Guid.NewGuid(),
                    Name = "Other"
                },
            });

        modelBuilder.Entity<EventType>()
            .HasData(new List<EventType>()
            {
                new EventType()
                {
                    Id = Guid.NewGuid(),
                    Name = "Birth"
                },
                new EventType()
                {
                    Id = Guid.NewGuid(),
                    Name = "Death"
                },
                new EventType()
                {
                    Id = Guid.NewGuid(),
                    Name = "Marriage"
                }
            });

        modelBuilder.Entity<Location>()
            .HasData(new List<Location>()
            {
                new Location()
                {
                    Id = Guid.NewGuid(),
                    Name = "Orem"
                },
                new Location()
                {
                    Id = Guid.NewGuid(),
                    Name = "Provo"
                },
                new Location()
                {
                    Id = Guid.NewGuid(),
                    Name = "New York"
                },
                new Location()
                {
                    Id = Guid.NewGuid(),
                    Name = "San Francisco"
                },
                new Location()
                {
                    Id = Guid.NewGuid(),
                    Name = "London"
                },
                new Location()
                {
                    Id = Guid.NewGuid(),
                    Name = "Tokyo"
                }
            });
    }
}
