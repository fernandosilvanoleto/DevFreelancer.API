using DevFreelancer.Application.ViewModels.Skill;
using DevFreelancer.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace DevFreelancer.Application.Queries.Skills.GetSkillById
{
    public class GetSkillByIdQueryHandler : IRequestHandler<GetSkillByIdQuery, SkillViewDetailsModel>
    {
        private readonly DevFreelancerDbContext _dbContext;
        public GetSkillByIdQueryHandler(DevFreelancerDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<SkillViewDetailsModel> Handle(GetSkillByIdQuery request, CancellationToken cancellationToken)
        {
            var skill = await _dbContext.Skills.SingleOrDefaultAsync(u => u.Id == request.Id);

            if (skill == null)
            {
                return null;
            }

            return new SkillViewDetailsModel(skill.Description, skill.CreatedAt);
        }
    }
}
