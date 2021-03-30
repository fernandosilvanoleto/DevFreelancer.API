using DevFreelancer.Core.Entities;
using DevFreelancer.Infrastructure.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DevFreelancer.Application.Commands.Skills.CreateSkill
{
    public class CreateSkillCommandHandler : IRequestHandler<CreateSkillCommand, int>
    {
        private readonly DevFreelancerDbContext _dbContext;
        public CreateSkillCommandHandler(DevFreelancerDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<int> Handle(CreateSkillCommand request, CancellationToken cancellationToken)
        {
            var skill = new Skill(request.Description);

            await _dbContext.Skills.AddAsync(skill);
            await _dbContext.SaveChangesAsync();

            return skill.Id;
        }
    }
}
