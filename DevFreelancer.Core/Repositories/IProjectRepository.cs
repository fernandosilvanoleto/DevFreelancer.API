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
        Task StartAndSaveChangesAsync(Project project);
        Task SaveChangesAsync();
        Task DeleteAndSaveChangesAsync(Project project);
        Task FinishAndSaveChangesAsync(Project project);
    }
}
