using DevFreelancer.Application.ViewModels;
using MediatR;
using System.Collections.Generic;

namespace DevFreelancer.Application.Queries.Projects.GetAllProjects
{
    public class GetAllProjectQuery : IRequest<List<ProjectViewModel>>
    {
        public GetAllProjectQuery(string query)
        {
            Query = query;
        }

        public string Query { get; private set; }
    }
}
