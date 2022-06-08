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




            // Apply Snake Case Naming Conventions
            
            builder.UseSnakeCaseNamingConvention();
        }
    }
}