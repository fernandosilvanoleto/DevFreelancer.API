using DevFreelancer.Core.Repositories;
using DevFreelancer.Infrastructure.Persistence;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DevFreelancer.Application.Commands.Projects.DeleteProject
{
    public class DeleteProjectCommandHandler : IRequestHandler<DeleteProjectCommand, Unit>
    {
        //private readonly DevFreelancerDbContext _dbContext;
        private readonly IProjectRepository _projectRepository;
        public DeleteProjectCommandHandler(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }
        public async Task<Unit> Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
        {
            //var project = _dbContext.Projects.SingleOrDefault(p => p.Id == request.Id);

            var project = await _projectRepository.GetByIdAsync(request.Id);

            //project.Cancel(); => JOGAR essa responsabilidade para o repository no DeleteAndSaveChangesAsync

            await _projectRepository.DeleteAndSaveChangesAsync(project);

            return Unit.Value;
        }
    }
}
