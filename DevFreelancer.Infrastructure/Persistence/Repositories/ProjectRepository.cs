using DevFreelancer.Core.Entities;
using DevFreelancer.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevFreelancer.Infrastructure.Persistence.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly DevFreelancerDbContext _dbContext;
        private readonly string _connectionString;
        // CLASSE DE ACESSO A DADOS
        public ProjectRepository(DevFreelancerDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _connectionString = configuration.GetConnectionString("DevFreelancer");
        }        

        public async Task<List<Project>> GetAllAsync()
        {
            return await _dbContext.Projects.ToListAsync();
        }

        public async Task<Project> GetByIdAsync(int id)
        {
            return await _dbContext.Projects
                .Include(p => p.Client)
                .Include(p => p.Freelancer)
                .SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task AddAsync(Project project)
        {
            await _dbContext.Projects.AddAsync(project);
            await _dbContext.SaveChangesAsync();
        }

        public async Task StartAndSaveChangesAsync(Project project)
        {
            //INICIAR PROJETO
            project.Start();

            // SÓ SALVAR ALTERAÇOES NO BANCO
            await _dbContext.SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAndSaveChangesAsync(Project project)
        {
            // CANCELAR OU DELETAR PROJETO
            // ISSO AQUI FAZ COMUNICAÇÃO COM O BANCO DE DADOS
            project.Cancel();

            // SÓ SALVAR ALTERAÇOES NO BANCO
            await SaveChangesAsync();
        }

        public async Task FinishAndSaveChangesAsync(Project project)
        {
            // FINALIZAR PROJETO
            // ISSO AQUI FAZ COMUNICAÇÃO COM O BANCO DE DADOS
            project.Finish();

            await _dbContext.SaveChangesAsync();
        }
    }
}
