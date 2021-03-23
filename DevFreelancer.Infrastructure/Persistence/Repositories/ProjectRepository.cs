using DevFreelancer.Core.Entities;
using DevFreelancer.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DevFreelancer.Infrastructure.Persistence.Repositories
{
    public class ProjectRepository //: IProjectRepository
    {
        //private readonly DevFreelancerDbContext _dbContext;
        //private readonly string _connectionString;
        //// CLASSE DE ACESSO A DADOS
        //public ProjectRepository(DevFreelancerDbContext dbContext, IConfiguration configuration)
        //{
        //    _dbContext = dbContext;
        //    _connectionString = configuration.GetConnectionString("DevFreelancer");
        //}

        //public async Task<List<Project>> GetAllAsync()
        //{
        //    return await _dbContext.Projects.ToListAsync();
        //}

        //public Task<Project> GetByIdAsync(int id)
        //{
        //    throw new System.NotImplementedException();
        //}
    }
}
