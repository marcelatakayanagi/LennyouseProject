using DataAccessLayer.Properties;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Recodme.RD.Lennyouse.DataLayer.MenuInfo;
using Recodme.RD.Lennyouse.DataLayer.RestaurantInfo;
using Recodme.RD.Lennyouse.DataLayer.UserInfo;

namespace DataAccessLayer.Contexts
{
    public class RestaurantContext : IdentityDbContext
    {
        public RestaurantContext() : base()
        {

        }

        public RestaurantContext(DbContextOptions<RestaurantContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Resources.ConnetionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Person>().HasOne(x => x.LennyouseUser).WithOne(x => x.Person);
            base.OnModelCreating(builder);
        }

        public DbSet<Course> Course { get; set; }
        public DbSet<DietaryRestrictions> DietaryRestriction { get; set; }
        public DbSet<Dish> Dish { get; set; }
        public DbSet<Meal> Meal { get; set; }
        public DbSet<Menu> Menu { get; set; }
        public DbSet<Serving> MenuDishCourse { get; set; }
        public DbSet<ClientRecord> ClientRecord { get; set; }
        public DbSet<Person> Person { get; set; }
        public DbSet<StaffRecord> StaffRecord { get; set; }
        public DbSet<StaffTitle> StaffTitle { get; set; }
        public DbSet<Title> Title { get; set; }
        public DbSet<Restaurant> Restaurant { get; set; }
        public DbSet<Booking> Booking { get; set; }
        public DbSet<Serving> Serving { get; set; }

    }
}
