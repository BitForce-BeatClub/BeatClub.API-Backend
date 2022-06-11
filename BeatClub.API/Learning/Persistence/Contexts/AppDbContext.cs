using BeatClub.API.Learning.Domain.Models;
using BeatClub.API.Shared.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BeatClub.API.Learning.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Message> Messages { get; set; }
        
        public DbSet<Creator> Creators { get; set; }
        
        public DbSet<Track> Tracks { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            //Users
            builder.Entity<User>().ToTable("Users");
            builder.Entity<User>().HasKey(p => p.Id);
            builder.Entity<User>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<User>().Property(p => p.Password).IsRequired().HasMaxLength(50);
            builder.Entity<User>().Property(p => p.TypeUser).IsRequired().HasMaxLength(50);
            
            
            //Relationships
            builder.Entity<User>()
                .HasMany(p => p.Messages)
                .WithOne(p => p.User)
                .HasForeignKey(p => p.UserId);
            
            
            //Messages
            builder.Entity<Message>().ToTable("Messages");
            builder.Entity<Message>().HasKey(p => p.Id);
            builder.Entity<Message>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Message>().Property(p => p.Content).IsRequired().HasMaxLength(120);
            //builder.Entity<Message>().Property(p => p.CreatAt).IsRequired();

            //Creators
            builder.Entity<Creator>().ToTable("Creators");
            builder.Entity<Creator>().HasKey(p => p.Id);
            builder.Entity<Creator>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Creator>().Property(p => p.Name).IsRequired().HasMaxLength(30);
            
            
            //Relationships

            builder.Entity<Creator>()
                .HasMany(p => p.Tracks)
                .WithOne(p => p.Creator)
                .HasForeignKey(p => p.CreatorId);
            
            //Tracks
            builder.Entity<Track>().ToTable("Tracks");
            builder.Entity<Track>().HasKey(p => p.Id);
            builder.Entity<Track>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Track>().Property(p => p.Cover).IsRequired();
            builder.Entity<Track>().Property(p => p.TrackUrl).IsRequired();
            builder.Entity<Track>().Property(p => p.Title).IsRequired().HasMaxLength(50);
            builder.Entity<Track>().Property(p => p.Genre).IsRequired();
            builder.Entity<Track>().Property(p => p.Description).IsRequired().HasMaxLength(80);
            builder.Entity<Track>().Property(p => p.Caption);
            builder.Entity<Track>().Property(p => p.Privacy).IsRequired();
            
            // Apply Snake Case Naming Conventions
            
            builder.UseSnakeCaseNamingConvention();
        }
    }
}