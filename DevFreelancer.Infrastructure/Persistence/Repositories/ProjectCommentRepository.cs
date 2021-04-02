using DevFreelancer.Core.Entities;
using DevFreelancer.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DevFreelancer.Infrastructure.Persistence.Repositories
{
    public class ProjectCommentRepository : IProjectCommentRepository
    {
        private readonly DevFreelancerDbContext _dbContext;
        private readonly string _connectionString;
        // CLASSE DE ACESSO A DADOS
        public ProjectCommentRepository(DevFreelancerDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _connectionString = configuration.GetConnectionString("DevFreelancer");
        }

        public async Task AddAsync(ProjectComment projectComment)
        {
            await _dbContext.ProjectComments.AddAsync(projectComment);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<ProjectComment>> GetAllProjectCommentsAsync()
        {
            return await _dbContext.ProjectComments
                .Include(pr => pr.Project)
                .Include(u => u.User)
                .ToListAsync();
        }

        public async Task<ProjectComment> GetProjectCommentByIdAsync(int id)
        {
            return await _dbContext.ProjectComments
                 .Include(pr => pr.Project)
                 .Include(u => u.User)
                 .SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
