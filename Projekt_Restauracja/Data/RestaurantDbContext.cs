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
        public DbSet<Image> Images { get; set; }

        public DbSet<Announcement> Announcements { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Dish> Dish { get; set; }
        public DbSet<User> Users { get; set; }
      //  public DbSet<Role> Roles { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .Property(u => u.email)
                .IsRequired();

          



            modelBuilder.Entity<CategoryGroup>()
                .HasKey(pg => new { pg.DishId, pg.CategoryId });
            modelBuilder.Entity<CategoryGroup>()
                .HasOne<Dish>(pg => pg.Dish)
                .WithMany(p => p.categoryGroups)
                .HasForeignKey(p => p.DishId);

            modelBuilder.Entity<CategoryGroup>()
                .HasOne<Category>(pg => pg.Category)
                .WithMany(g => g.categoryGroups)
                .HasForeignKey(g => g.CategoryId);

        }

        public DbSet<CategoryGroup> CategoryGroup { get; set; }

        public DbSet<Category> Category { get; set; }


    }
}
