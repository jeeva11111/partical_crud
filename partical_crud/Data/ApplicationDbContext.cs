using Microsoft.EntityFrameworkCore;
using partical_crud.Models;
using partical_crud.Models.CourseLearn;


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

        public DbSet<PlanningCourse> PlanningCourse { get; set; }
    }
}
