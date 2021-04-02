using DevFreelancer.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DevFreelancer.Core.Repositories
{
    public interface IProjectCommentRepository
    {
        Task<List<ProjectComment>> GetAllProjectCommentsAsync();
        Task<ProjectComment> GetProjectCommentByIdAsync(int id);
        Task AddAsync(ProjectComment projectComment);
        Task SaveChangesAsync();

    }
}
