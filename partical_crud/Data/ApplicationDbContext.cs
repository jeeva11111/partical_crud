using Microsoft.EntityFrameworkCore;
using partical_crud.Models;


namespace partical_crud.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<UserInfo> UserInfo { get; set; }
        public DbSet<Country> Country { get; set; }
        public DbSet<State> states { get; set; }
        public DbSet<City> City { get; set; }

        public DbSet<UserViewModel> AccountInfo { get; set; }
    }
}
