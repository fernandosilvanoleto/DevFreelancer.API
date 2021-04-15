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
        private readonly IUserSkillRepository _userSkillRepository;
        public GetUserSkillByIdQueryHandler(IUserSkillRepository userSkillRepository)
        {
            _userSkillRepository = userSkillRepository;
        }
        public async Task<UserSkillViewModel> Handle(GetUserSkillByIdQuery request, CancellationToken cancellationToken)
        {
            var userSkill = await _userSkillRepository.GetByIdAsync(request.Id);

            var userSkillViewModel = new UserSkillViewModel();

            //if (userSkill == null)
            //{
            //    return null;
            //}

            //var userSkillViewModel = new UserSkillViewModel(
            //        userSkill.Id,
            //        userSkill.User.FullName,
            //        userSkill.Skills.Description
            //    );

            return userSkillViewModel;
        }
    }
}
