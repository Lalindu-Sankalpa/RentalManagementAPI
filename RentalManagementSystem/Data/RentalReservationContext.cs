
using Microsoft.EntityFrameworkCore;

namespace RentalManagementSystem.Data
{
    public class RentalReservationContext : DbContext
    {
        public RentalReservationContext(DbContextOptions<RentalReservationContext> options) : base(options) //pass options
        {

        }
        public DbSet<Camera> Cameras { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Lense> Lenses { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<CameraType> CameraTypes { get; set; }
        public DbSet<Staffplan> Staffplans { get; set; }
        public DbSet<User> Users { get; set; }
    }
}