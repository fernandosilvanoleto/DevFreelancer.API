using DevFreelancer.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DevFreelancer.Core.Repositories
{
    public interface IUserSkillRepository
    {
        Task<List<UserSkill>> GetAllAsync();
        Task<UserSkill> GetByIdAsync(int id);
        Task AddAsync(UserSkill userSkill);
    }
}
