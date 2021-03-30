using DevFreelancer.Application.ViewModels.UserSkill;
using MediatR;
using System.Collections.Generic;

namespace DevFreelancer.Application.Queries.UserSkill.GetAllUserSkill
{
    public class GetAllUserSkillQuery : IRequest<List<UserSkillViewAllModel>>
    {
        
    }
}
