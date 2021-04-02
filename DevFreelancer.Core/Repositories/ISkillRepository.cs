using DevFreelancer.Core.DTOs;
using DevFreelancer.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DevFreelancer.Core.Repositories
{
    public interface ISkillRepository
    {
        Task<List<SkillDTO>> GetAll();
        Task<Skill> GetByIdAsync(int id);
        Task AddAsync(Skill skill);
    }
}
