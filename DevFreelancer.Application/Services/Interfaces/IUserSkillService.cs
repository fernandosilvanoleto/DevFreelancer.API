using DevFreelancer.Application.InputModels.UserSkill;
using DevFreelancer.Application.ViewModels.UserSkill;
using System.Collections.Generic;

namespace DevFreelancer.Application.Services.Interfaces
{
    public interface IUserSkillService
    {
        UserSkillViewModel GetUserSkill(int id);
        List<UserSkillViewAllModel> GetAll();
        int Create(CreateUserSkillInputModel inputModel);
    }
}
