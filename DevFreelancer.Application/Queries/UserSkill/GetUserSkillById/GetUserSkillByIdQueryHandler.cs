using DevFreelancer.Application.ViewModels.UserSkill;
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
        public GetUserSkillByIdQueryHandler(DevFreelancerDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<UserSkillViewModel> Handle(GetUserSkillByIdQuery request, CancellationToken cancellationToken)
        {
            var userSkill = await _dbContext.UserSkills
                .Include(u => u.User)
                .Include(s => s.Skills)
                .SingleOrDefaultAsync(us => us.Id == request.Id);

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
