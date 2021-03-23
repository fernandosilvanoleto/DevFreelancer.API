using DevFreelancer.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DevFreelancer.Core.Repositories
{
    public interface IProjectRepository
    {
        Task<List<Project>> GetAllAsync();
        Task<Project> GetByIdAsync(int id);
    }
}
