using DevFreelancer.Application.ViewModels;
using DevFreelancer.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DevFreelancer.Application.Queries.Projects.GetAllProjects
{
    public class GetAllProjectQueryHandler : IRequestHandler<GetAllProjectQuery, List<ProjectViewModel>>
    {
        private readonly DevFreelancerDbContext _dbContext;
        public GetAllProjectQueryHandler(DevFreelancerDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<ProjectViewModel>> Handle(GetAllProjectQuery request, CancellationToken cancellationToken)
        {
            var projects = _dbContext.Projects;

            var projectsViewModel = await projects
                .Select(p => new ProjectViewModel(p.Id, p.Title, p.CreatedAt))
                .ToListAsync();

            return projectsViewModel;
        }
    }
}
