using DevFreelancer.Application.ViewModels;
using MediatR;
using System.Collections.Generic;
namespace DevFreelancer.Application.Queries.Skills.GetAllSkills
{
    public class GetAllSkillsQuery : IRequest<List<SkillViewModel>>
    {

    }
}
