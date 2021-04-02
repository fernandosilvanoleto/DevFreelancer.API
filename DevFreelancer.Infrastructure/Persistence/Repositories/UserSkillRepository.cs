using DevFreelancer.Core.Entities;
using DevFreelancer.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DevFreelancer.Infrastructure.Persistence.Repositories
{
    public class UserSkillRepository : IUserSkillRepository
    {
        private readonly string _connectionString;
        private readonly DevFreelancerDbContext _dbContext;
        public UserSkillRepository(DevFreelancerDbContext dbContext, IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DevFreelancer");
            _dbContext = dbContext;
        }

        public async Task AddAsync(UserSkill userSkill)
        {
            await _dbContext.UserSkills.AddAsync(userSkill);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<UserSkill>> GetAllAsync()
        {
            // CUIDADO AQUI => OS INCLUDES FICAM AQUI AGORAS
            return await _dbContext.UserSkills
                .Include(u => u.User)
                .Include(s => s.Skills)
                .ToListAsync();
        }

        public async Task<UserSkill> GetByIdAsync(int id)
        {
            return await _dbContext.UserSkills
                .Include(u => u.User)
                .Include(s => s.Skills)
                .SingleOrDefaultAsync(us => us.Id == id);
        }
    }
}
