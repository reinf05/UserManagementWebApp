using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using UserManagementWebApp.Models;


//Database context, responsible to create the database
namespace UserManagementWebApp.Data
{
    public class UserManagementDbContext : DbContext
    {
        public UserManagementDbContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Name = "Seeded User",
                    Email = "seeded@example.com",
                    BirthDate = new DateOnly(1995, 1, 1),
                }
            );
        }
    }
}
