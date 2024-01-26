using EntityFrameworkMvc.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace EntityFrameworkMvc.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>  
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }



        public DbSet<Author> Authors { get; set; }

        public DbSet<Book> Books { get; set; }

        public DbSet<AuthorProfile> AuthorProfiles { get; set; }

        public DbSet<Publisher> Publishers { get; set; }

        public DbSet<AuthorPublisher> AuthorPublishers { get; set; }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AuthorPublisher>().HasKey(ap => new { ap.AuthorId, ap.PublisherId });

            modelBuilder.Entity<Author>()
                .HasMany(a => a.AuthorPublishers)
                .WithOne(ap => ap.Author)
                .HasForeignKey(ap => ap.AuthorId);

            modelBuilder.Entity<Publisher>()
                .HasMany(p => p.AuthorPublishers)
                .WithOne(ap => ap.Publisher)
                .HasForeignKey(ap => ap.PublisherId);
        }
    }
}
