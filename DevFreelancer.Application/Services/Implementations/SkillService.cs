using Dapper;
using DevFreelancer.Application.InputModels.Skill;
using DevFreelancer.Application.Services.Interfaces;
using DevFreelancer.Application.ViewModels;
using DevFreelancer.Application.ViewModels.Skill;
using DevFreelancer.Core.Entities;
using DevFreelancer.Infrastructure.Persistence;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DevFreelancer.Application.Services.Implementations
{
    public class SkillService : ISkillService
    {
        private readonly DevFreelancerDbContext _dbContext;
        private readonly string _connectionString;
        public SkillService(DevFreelancerDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _connectionString = configuration.GetConnectionString("DevFreelancer");
        }

        public int Create(CreateSkillInputModel inputModel)
        {
            var skill = new Skill(inputModel.Description);

            _dbContext.Skills.Add(skill);
            _dbContext.SaveChanges();

            return skill.Id;
        }

        public List<SkillViewModel> GetAll()
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                var script = "SELECT Id, Description FROM Skills";

                return sqlConnection.Query<SkillViewModel>(script).ToList();
            }
            //var skills = _dbContext.Skills;

            //var skillsViewModel = skills
            //    .Select(s => new SkillViewModel(s.Id, s.Description))
            //    .ToList();

            //return skillsViewModel;
        }

        public SkillViewDetailsModel GetSkill(int id)
        {
            var skill = _dbContext.Skills.SingleOrDefault(u => u.Id == id);

            if (skill == null)
            {
                return null;
            }

            return new SkillViewDetailsModel(skill.Description, skill.CreatedAt);
        }
    }
}
