using BeatClub.API.BeatClub.Domain.Models;
using BeatClub.API.Shared.Extensions;
using Microsoft.EntityFrameworkCore;

namespace BeatClub.API.Shared.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Track> Tracks { get; set; }
        public DbSet<Publication> Publications { get; set; }
        public DbSet<Membership> Memberships { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Payment> Payments { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            //Users
            builder.Entity<User>().ToTable("Users");
            builder.Entity<User>().HasKey(p => p.id);
            builder.Entity<User>().Property(p => p.id).IsRequired();
            builder.Entity<User>().Property(p => p.nickName).IsRequired().HasMaxLength(50);
            builder.Entity<User>().Property(p => p.firstName).IsRequired().HasMaxLength(50);
            builder.Entity<User>().Property(p => p.lastName).IsRequired().HasMaxLength(50);
            builder.Entity<User>().Property(p => p.userType).IsRequired().HasMaxLength(50);
            builder.Entity<User>().Property(p => p.urlToImage).IsRequired().HasMaxLength(200);
            builder.Entity<User>().Property(p => p.location).IsRequired().HasMaxLength(150);
            builder.Entity<User>().Property(p => p.email).IsRequired().HasMaxLength(150);
            builder.Entity<User>().Property(p => p.membership).IsRequired().HasMaxLength(50);
            builder.Entity<User>().Property(p => p.description).IsRequired().HasMaxLength(200);
            
            //Payments
            builder.Entity<Payment>().ToTable("Payments");
            builder.Entity<Payment>().HasKey(p => p.id);
            builder.Entity<Payment>().Property(p => p.id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Payment>().Property(p => p.plan).IsRequired().HasMaxLength(50);
            builder.Entity<Payment>().Property(p => p.price).IsRequired();
            builder.Entity<Payment>().Property(p => p.date).IsRequired();
            builder.Entity<Payment>().Property(p => p.userId).IsRequired();
            
            //Messages
            builder.Entity<Message>().ToTable("Messages");
            builder.Entity<Message>().HasKey(p => p.id);
            builder.Entity<Message>().Property(p => p.id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Message>().Property(p => p.content).IsRequired().HasMaxLength(120);
            builder.Entity<Message>().Property(p => p.userIdFrom).IsRequired();
            builder.Entity<Message>().Property(p => p.userIdTo).IsRequired();
            builder.Entity<Message>().Property(p => p.messageDate).IsRequired();
            
            //Track
            builder.Entity<Track>().ToTable("Tracks");
            builder.Entity<Track>().HasKey(p => p.id);
            builder.Entity<Track>().Property(p => p.id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Track>().Property(p => p.title).IsRequired().HasMaxLength(50);
            builder.Entity<Track>().Property(p => p.privacy).IsRequired().HasMaxLength(50);
            builder.Entity<Track>().Property(p => p.genre).IsRequired().HasMaxLength(50);
            builder.Entity<Track>().Property(p => p.artist).IsRequired().HasMaxLength(50);
            builder.Entity<Track>().Property(p => p.cover).IsRequired().HasMaxLength(200);
            builder.Entity<Track>().Property(p => p.source).IsRequired().HasMaxLength(200);
            builder.Entity<Track>().Property(p => p.publishDate).IsRequired();

            //Publication
            builder.Entity<Publication>().ToTable("Publications");
            builder.Entity<Publication>().HasKey(p => p.Id);
            builder.Entity<Publication>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Publication>().Property(p => p.Title).IsRequired().HasMaxLength(50);
            builder.Entity<Publication>().Property(p => p.Description).IsRequired().HasMaxLength(120);
            builder.Entity<Publication>().Property(p => p.CreateAt).IsRequired();
           
            //Membership
            builder.Entity<Membership>().ToTable("Memberships");
            builder.Entity<Membership>().HasKey(p => p.Id);
            builder.Entity<Membership>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Membership>().Property(p => p.Title).IsRequired().HasMaxLength(50);
            builder.Entity<Membership>().Property(p => p.Price).IsRequired();
            builder.Entity<Membership>().Property(p => p.Feature).IsRequired().HasMaxLength(120);
            builder.Entity<Membership>().Property(p => p.Description).IsRequired().HasMaxLength(120);
            builder.Entity<Membership>().Property(p => p.UrlToImage).IsRequired().HasMaxLength(200);
            
            //Reviews
            builder.Entity<Review>().ToTable("Reviews");
            builder.Entity<Review>().HasKey(p => p.Id);
            builder.Entity<Review>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Review>().Property(p => p.Description).IsRequired().HasMaxLength(120);
            builder.Entity<Review>().Property(p => p.Qualification).IsRequired();
            builder.Entity<Review>().Property(p => p.UserArtistId).IsRequired();
            builder.Entity<Review>().Property(p => p.UserProducerId).IsRequired();
            builder.Entity<Review>().Property(p => p.CreateAt).IsRequired();
            
            // Apply Snake Case Naming Conventions
            
            builder.UseSnakeCaseNamingConvention();
        }
    }
}