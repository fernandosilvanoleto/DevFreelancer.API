using DevFreelancer.Core.Entities;
using DevFreelancer.Core.Repositories;
using DevFreelancer.Infrastructure.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DevFreelancer.Application.Commands.UserSkills.UserSkillCommand
{
    public class UserSkillCommandHandler : IRequestHandler<UserSkillCommand, int>
    {
        //private readonly DevFreelancerDbContext _dbContext;
        private readonly IUserSkillRepository _userSkillRepository;
        public UserSkillCommandHandler(IUserSkillRepository userSkillRepository)
        {
            _userSkillRepository = userSkillRepository;
        }
        public async Task<int> Handle(UserSkillCommand request, CancellationToken cancellationToken)
        {
            var userSkill = new UserSkill(request.IdUser, request.IdSkill);

            await _userSkillRepository.AddAsync(userSkill);

            return userSkill.Id;
        }
    }
}
