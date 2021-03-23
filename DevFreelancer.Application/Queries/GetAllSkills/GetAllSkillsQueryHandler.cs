using Dapper;
using DevFreelancer.Application.ViewModels;
using DevFreelancer.Core.DTOs;
using DevFreelancer.Core.Repositories;
using MediatR;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DevFreelancer.Application.Queries.GetAllSkills
{
    public class GetAllSkillsQueryHandler //: IRequestHandler<GetAllSkillsQuery, List<SkillDTO>>
    {
        //private readonly ISkillRepository _skillRepository;
        //public GetAllSkillsQueryHandler(ISkillRepository skillRepository)
        //{
        //    _skillRepository = skillRepository;
        //}
        //public async Task<List<SkillDTO>> Handle(GetAllSkillsQuery request, CancellationToken cancellationToken)
        //{
        //    return await _skillRepository.GetAll();

        //    //using (var sqlConnection = new SqlConnection(_connectionString))
        //    //{
        //    //    sqlConnection.Open();

        //    //    var script = "SELECT Id, Description FROM Skills";

        //    //    var skills = await sqlConnection.QueryAsync<SkillViewModel>(script);

        //    //    return skills.ToList();
        //    //}

        //    // COM EF CORE
        //    //var skills = _dbContext.Skills;

        //    //var skillsViewModel = skills
        //    //    .Select(s => new SkillViewModel(s.Id, s.Description))
        //    //    .ToList();

        //    //return skillsViewModel;
        //}
    }
}
