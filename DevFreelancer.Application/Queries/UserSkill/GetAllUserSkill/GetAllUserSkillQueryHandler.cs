using DevFreelancer.Application.ViewModels.UserSkill;
using DevFreelancer.Core.Repositories;
using DevFreelancer.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DevFreelancer.Application.Queries.UserSkill.GetAllUserSkill
{
    public class GetAllUserSkillQueryHandler : IRequestHandler<GetAllUserSkillQuery, List<UserSkillViewAllModel>>
    {
        private readonly IUserSkillRepository _userSkillRepository;
        public GetAllUserSkillQueryHandler(IUserSkillRepository userSkillRepository)
        {
            _userSkillRepository = userSkillRepository;
        }
        public async Task<List<UserSkillViewAllModel>> Handle(GetAllUserSkillQuery request, CancellationToken cancellationToken)
        {
            //var userSkills = _dbContext.UserSkills;
            var userSkills = await _userSkillRepository.GetAllAsync();

            var userSkillViewAllModel = new List<UserSkillViewAllModel>();

            //INCLUDES FORAM PARA O REPOSITORY
            //var userSkillViewAllModel = userSkills                
            //    .Select(us => new UserSkillViewAllModel(us.User.FullName, us.Skills.Description))
            //    .ToList();

            return userSkillViewAllModel;
        }
    }
}
