using DevFreelancer.Application.ViewModels.UserSkill;
using DevFreelancer.Core.Repositories;
using DevFreelancer.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DevFreelancer.Application.Queries.UserSkill.GetUserSkillById
{
    public class GetUserSkillByIdQueryHandler : IRequestHandler<GetUserSkillByIdQuery, UserSkillViewModel>
    {
        private readonly DevFreelancerDbContext _dbContext;
        private readonly IUserSkillRepository _userSkillRepository;
        public GetUserSkillByIdQueryHandler(DevFreelancerDbContext dbContext, IUserSkillRepository userSkillRepository)
        {
            _dbContext = dbContext;
            _userSkillRepository = userSkillRepository;
        }
        public async Task<UserSkillViewModel> Handle(GetUserSkillByIdQuery request, CancellationToken cancellationToken)
        {
            var userSkill = await _userSkillRepository.GetByIdAsync(request.Id);

            if (userSkill == null)
            {
                return null;
            }

            var userSkillViewModel = new UserSkillViewModel(
                    userSkill.Id,
                    userSkill.User.FullName,
                    userSkill.Skills.Description
                );

            return userSkillViewModel;
        }
    }
}
