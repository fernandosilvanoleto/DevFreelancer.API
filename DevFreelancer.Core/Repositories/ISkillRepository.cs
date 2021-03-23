using DevFreelancer.Core.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DevFreelancer.Core.Repositories
{
    public interface ISkillRepository
    {
        Task<List<SkillDTO>> GetAll();
    }
}
