using Microsoft.EntityFrameworkCore;
using Projekt_Restauracja;
using Projekt_Restauracja.Models;

namespace Projekt_Restauracja.Data
{
    public class RestaurantDbContext : DbContext
    {


        public RestaurantDbContext(DbContextOptions<RestaurantDbContext> options)
            : base(options)
        {
        }
        public DbSet<Announcement> Announcements { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Dish> Dish { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .Property(u => u.email)
                .IsRequired();

            modelBuilder.Entity<Role>()
              .Property(u => u.Name)
              .IsRequired();



            modelBuilder.Entity<Category>()
                .HasMany(p => p.Dishes)
                .WithMany(p => p.Categories)
                .UsingEntity<CategoryGroup>(
                    j => j
                        .HasOne(pt => pt.Dish)
                        .WithMany(t => t.CategoryGroups)
                        .HasForeignKey(pt => pt.DishId),
                    j => j
                        .HasOne(pt => pt.Category)
                        .WithMany(p => p.CategoryGroups)
                        .HasForeignKey(pt => pt.CategoryId),
                    j =>
                    {
                        j.HasKey(t => new { t.DishId, t.CategoryId });
                    });

        }

        public DbSet<CategoryGroup> CategoryGroup { get; set; }

        public DbSet<Category> Category { get; set; }


    }
}
