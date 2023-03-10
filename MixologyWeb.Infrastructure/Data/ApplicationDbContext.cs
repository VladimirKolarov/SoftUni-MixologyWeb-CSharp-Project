using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MixologyWeb.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Cocktail>()
                    .HasIndex(c => c.Name)
                    .IsUnique(true);

            builder.Entity<Ingredient>()
                    .HasIndex(i => i.Name)
                    .IsUnique(true);

            builder.Entity<Performer>()
                    .HasIndex(p => p.Name)
                    .IsUnique(true);


            //builder.Entity<Cocktail>()
            //    .HasMany(s => s.Songs)
            //    .WithMany(c => c.Cocktails);
        }

        public DbSet<Cocktail> Cocktails { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Performer> Performers { get; set; }
        public DbSet<Song> Songs { get; set; }
    }
}