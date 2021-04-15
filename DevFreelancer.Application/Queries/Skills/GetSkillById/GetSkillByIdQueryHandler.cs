using DevFreelancer.Application.ViewModels.Skill;
using DevFreelancer.Core.Repositories;
using DevFreelancer.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace DevFreelancer.Application.Queries.Skills.GetSkillById
{
    public class GetSkillByIdQueryHandler : IRequestHandler<GetSkillByIdQuery, SkillViewDetailsModel>
    {
        private readonly ISkillRepository _skillRepository;
        public GetSkillByIdQueryHandler(ISkillRepository skillRepository)
        {
            _skillRepository = skillRepository;
        }
        public async Task<SkillViewDetailsModel> Handle(GetSkillByIdQuery request, CancellationToken cancellationToken)
        {
            var skill = await _skillRepository.GetByIdAsync(request.Id);

            //if (skill == null)
            //{
            //    return null;
            //}

            return new SkillViewDetailsModel(skill.Description, skill.CreatedAt);
        }
    }
}
