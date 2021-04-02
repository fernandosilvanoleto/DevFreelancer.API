using DevFreelancer.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DevFreelancer.Core.Repositories
{
    public interface IProjectRepository
    {
        Task<List<Project>> GetAllAsync();
        Task<Project> GetByIdAsync(int id);
        Task AddAsync(Project project);
        Task StartAsync(Project project);
        Task SaveChangesAsync();
        Task DeleteAsync(Project project);
        Task FinishAsync(Project project);
    }
}
