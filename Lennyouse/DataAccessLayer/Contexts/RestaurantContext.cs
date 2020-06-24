using Recodme.RD.Lennyouse.DataAccessLayer.Properties;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Recodme.RD.Lennyouse.DataLayer.MenuInfo;
using Recodme.RD.Lennyouse.DataLayer.RestaurantInfo;
using Recodme.RD.Lennyouse.DataLayer.UserInfo;

namespace Recodme.RD.Lennyouse.DataAccessLayer.Contexts
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

        public DbSet<Course> Courses { get; set; }
        public DbSet<DietaryRestriction> DietaryRestrictions { get; set; }
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Meal> Meals { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<ClientRecord> ClientRecords { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<StaffRecord> StaffRecords { get; set; }
        public DbSet<StaffTitle> StaffTitles { get; set; }
        public DbSet<Title> Titles { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Serving> Servings { get; set; }
        //public DbSet<LennyouseUser> LennyouseUsers { get; set; }

    }
}
