using BeatClub.API.Learning.Domain.Models;
using BeatClub.API.Shared.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
        public DbSet<SongList> SongLists { get; set; }
        public DbSet<Song> Songs { get; set; }
        
        public DbSet<Publication> Publications { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            //Users
            builder.Entity<User>().ToTable("Users");
            builder.Entity<User>().HasKey(p => p.Id);
            builder.Entity<User>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<User>().Property(p => p.Nickname).IsRequired().HasMaxLength(50);
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
            
            //SongList
            builder.Entity<SongList>().ToTable("SongLists");
            builder.Entity<SongList>().HasKey(p => p.Id);
            builder.Entity<SongList>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<SongList>().Property(p => p.Name).IsRequired().HasMaxLength(50);
            builder.Entity<SongList>().Property(p => p.Description).IsRequired().HasMaxLength(120);
            builder.Entity<SongList>().Property(p => p.UserId).IsRequired();
            //builder.Entity<SongList>().Property(p => p.CreateAt).IsRequired();
                
            //Song
            builder.Entity<Song>().ToTable("Songs");
            builder.Entity<Song>().HasKey(p => p.Id);
            builder.Entity<Song>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Song>().Property(p => p.Name).IsRequired().HasMaxLength(50);
            builder.Entity<Song>().Property(p => p.Gender).IsRequired().HasMaxLength(50);
            builder.Entity<Song>().Property(p => p.Description).IsRequired().HasMaxLength(120);
            builder.Entity<Song>().Property(p => p.SongListId).IsRequired();
            //builder.Entity<Song>().Property(p => p.CreateAt).IsRequired();

            //Publication
            builder.Entity<Publication>().ToTable("Publications");
            builder.Entity<Publication>().HasKey(p => p.Id);
            builder.Entity<Publication>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Publication>().Property(p => p.Name).IsRequired().HasMaxLength(50);
            builder.Entity<Publication>().Property(p => p.Description).IsRequired().HasMaxLength(120);
            builder.Entity<SongList>().Property(p => p.UserId).IsRequired();

            // Apply Snake Case Naming Conventions
            
            builder.UseSnakeCaseNamingConvention();
        }
    }
}