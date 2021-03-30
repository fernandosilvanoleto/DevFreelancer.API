using DevFreelancer.Core.Entities;
using DevFreelancer.Infrastructure.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DevFreelancer.Application.Commands.UserSkills.UserSkillCommand
{
    public class UserSkillCommandHandler : IRequestHandler<UserSkillCommand, int>
    {
        private readonly DevFreelancerDbContext _dbContext;
        private object inputModel;

        public UserSkillCommandHandler(DevFreelancerDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<int> Handle(UserSkillCommand request, CancellationToken cancellationToken)
        {
            var userSkill = new UserSkill(request.IdUser, request.IdSkill);

            await _dbContext.UserSkills.AddAsync(userSkill);
            await _dbContext.SaveChangesAsync();

            return userSkill.Id;
        }
    }
}
