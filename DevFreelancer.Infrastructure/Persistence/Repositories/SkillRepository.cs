using Dapper;
using DevFreelancer.Core.DTOs;
using DevFreelancer.Core.Entities;
using DevFreelancer.Core.Repositories;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevFreelancer.Infrastructure.Persistence.Repositories
{
    public class SkillRepository : ISkillRepository
    {
        private readonly string _connectionString;
        private readonly DevFreelancerDbContext _dbContext;
        public SkillRepository(DevFreelancerDbContext dbContext, IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DevFreelancer");
            _dbContext = dbContext;
        }

        public async Task AddAsync(Skill skill)
        {
            await _dbContext.Skills.AddAsync(skill);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<SkillDTO>> GetAll()
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                var script = "SELECT Id, Description FROM Skills";

                var skills = await sqlConnection.QueryAsync<SkillDTO>(script);

                return skills.ToList();
            }
        }

        public Task<Skill> GetByIdAsync(int id)
        {
            return _dbContext.Skills.SingleOrDefaultAsync(u => u.Id == id);
        }
    }
}
