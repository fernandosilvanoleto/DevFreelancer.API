using DevFreelancer.Application.InputModels.Skill;
using DevFreelancer.Application.ViewModels;
using DevFreelancer.Application.ViewModels.Skill;
using System.Collections.Generic;

namespace DevFreelancer.Application.Services.Interfaces
{
    public interface ISkillService
    {
        List<SkillViewModel> GetAll();
        SkillViewDetailsModel GetSkill(int id);
        int Create(CreateSkillInputModel inputModel);
    }
}
