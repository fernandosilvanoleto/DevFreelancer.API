using DevFreelancer.Core.Repositories;
using DevFreelancer.Infrastructure.Persistence;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DevFreelancer.Application.Commands.Projects.StartProject
{
    public class StartProjectCommandHandler : IRequestHandler<StartProjectCommand, Unit>
    {
        //private readonly DevFreelancerDbContext _dbContext;
        private readonly IProjectRepository _projectRepository;
        public StartProjectCommandHandler(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }
        public async Task<Unit> Handle(StartProjectCommand request, CancellationToken cancellationToken)
        {
            var project = await _projectRepository.GetByIdAsync(request.Id);

            //project.Start();

            await _projectRepository.StartAndSaveChangesAsync(project);

            return Unit.Value;
        }
    }
}
