using DevFreelancer.Application.ViewModels;
using DevFreelancer.Core.Repositories;
using DevFreelancer.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DevFreelancer.Application.Queries.Projects.GetProjectById
{
    public class GetProjectByIdQueryHandler : IRequestHandler<GetProjectByIdQuery, ProjectDetailsViewModel>
    {
        //private readonly DevFreelancerDbContext _dbContext;
        private readonly IProjectRepository _projectRepository;
        public GetProjectByIdQueryHandler(IProjectRepository projectRepository)
        {
            //_dbContext = dbContext;
            _projectRepository = projectRepository;
        }
        public async Task<ProjectDetailsViewModel> Handle(GetProjectByIdQuery request, CancellationToken cancellationToken)
        {
            var project = await _projectRepository.GetByIdAsync(request.Id);

            if (project == null) return null;

            var projectDetailsViewModel = new ProjectDetailsViewModel();

            projectDetailsViewModel = new ProjectDetailsViewModel(
                    project.Id,
                    project.Title,
                    project.Description,
                    project.TotalCost,
                    project.StartedAt,
                    project.FinishedAt,
                    project.Client.FullName,
                    project.Freelancer.FullName
                );

            return projectDetailsViewModel;
        }
    }
}
