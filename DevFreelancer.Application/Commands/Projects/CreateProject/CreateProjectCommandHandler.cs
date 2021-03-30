using DevFreelancer.Core.Entities;
using DevFreelancer.Infrastructure.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DevFreelancer.Application.Commands.Projects.CreateProject
{
    public class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand, int>
    {
        private readonly DevFreelancerDbContext _dbContext;
        public CreateProjectCommandHandler(DevFreelancerDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        // TRATAR AS INFORMAÇÕES E GUARDAR AS INFORMAÇÕES NO BANCO DE 
        public async Task<int> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
        {
            var project = new Project(request.Title, request.Description, request.IdClient, request.IdFreelancer, request.TotalCost, request.FinishedAt);

            await _dbContext.Projects.AddAsync(project);
            await _dbContext.SaveChangesAsync();

            return project.Id;
        }
    }
}
