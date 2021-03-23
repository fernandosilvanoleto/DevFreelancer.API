using DevFreelancer.Application.InputModels.UserSkill;
using DevFreelancer.Application.Services.Interfaces;
using DevFreelancer.Application.ViewModels.UserSkill;
using DevFreelancer.Core.Entities;
using DevFreelancer.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DevFreelancer.Application.Services.Implementations
{
    public class UserSkillService : IUserSkillService
    {
        private readonly DevFreelancerDbContext _dbContext;
        public UserSkillService(DevFreelancerDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public int Create(CreateUserSkillInputModel inputModel)
        {
            var userSkill = new UserSkill(inputModel.IdUser, inputModel.IdSkill);

            _dbContext.UserSkills.Add(userSkill);
            _dbContext.SaveChanges();

            return userSkill.Id;
        }

        public List<UserSkillViewAllModel> GetAll()
        {
            var userSkills = _dbContext.UserSkills;

            var userSkillViewAllModel = userSkills
                .Include(u => u.User)
                .Include(s => s.Skills)
                .Select(us => new UserSkillViewAllModel(us.User.FullName, us.Skills.Description))
                .ToList();

            return userSkillViewAllModel;
        }

        public UserSkillViewModel GetUserSkill(int id)
        {
            var userSkill = _dbContext.UserSkills
                .Include(u => u.User)
                .Include(s => s.Skills)
                .SingleOrDefault(us => us.Id == id);

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
