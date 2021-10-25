using GymDiaryAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace GymDiaryAPI.Repositories
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        
        public DbSet<Diary> Diaries { get; set; }
        
        public DbSet<Exercise> Exercises { get; set; }
    }
}
