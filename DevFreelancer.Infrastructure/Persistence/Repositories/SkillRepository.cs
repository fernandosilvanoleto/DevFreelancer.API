using Dapper;
using DevFreelancer.Core.DTOs;
using DevFreelancer.Core.Repositories;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevFreelancer.Infrastructure.Persistence.Repositories
{
    public class SkillRepository //: ISkillRepository
    {        
        //private readonly string _connectionString;
        //public SkillRepository(IConfiguration configuration)
        //{
        //    _connectionString = configuration.GetConnectionString("DevFreelancer");
        //}

        //public async Task<List<SkillDTO>> GetAll()
        //{
        //    using (var sqlConnection = new SqlConnection(_connectionString))
        //    {
        //        sqlConnection.Open();

        //        var script = "SELECT Id, Description FROM Skills";

        //        var skills = await sqlConnection.QueryAsync<SkillDTO>(script);

        //        return skills.ToList();
        //    }
        //}
    }
}
