using DevFreelancer.Application.ViewModels.UserSkill;
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
        private readonly DevFreelancerDbContext _dbContext;
        public GetAllUserSkillQueryHandler(DevFreelancerDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<UserSkillViewAllModel>> Handle(GetAllUserSkillQuery request, CancellationToken cancellationToken)
        {
            var userSkills = _dbContext.UserSkills;

            var userSkillViewAllModel = await userSkills
                .Include(u => u.User)
                .Include(s => s.Skills)
                .Select(us => new UserSkillViewAllModel(us.User.FullName, us.Skills.Description))
                .ToListAsync();

            return userSkillViewAllModel;
        }
    }
}
