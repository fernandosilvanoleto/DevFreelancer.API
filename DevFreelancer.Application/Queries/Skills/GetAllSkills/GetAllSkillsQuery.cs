using DevFreelancer.Application.ViewModels;
using DevFreelancer.Core.DTOs;
using MediatR;
using System.Collections.Generic;
namespace DevFreelancer.Application.Queries.Skills.GetAllSkills
{
    public class GetAllSkillsQuery : IRequest<List<SkillDTO>>
    {

    }
}
