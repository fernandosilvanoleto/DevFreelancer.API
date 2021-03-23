using DevFreelancer.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace DevFreelancer.Infrastructure.Persistence
{
    public class DevFreelancerDbContext : DbContext
    {
        public DevFreelancerDbContext(DbContextOptions<DevFreelancerDbContext> options) 
            : base(options)
        {
            
        }
        public DbSet<Project> Projects { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<UserSkill> UserSkills { get; set; }
        public DbSet<ProjectComment> ProjectComments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // BUSCAR TODAS AS CONFIGURATIONS DA PASTA CONFIGURATIONS
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
