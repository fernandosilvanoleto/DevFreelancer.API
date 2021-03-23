using DevFreelancer.Core.Entities;
using DevFreelancer.Infrastructure.Persistence;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DevFreelancer.Application.Commands.CreateProject
{
    public class CreateProjectCommandHandler //: IRequestHandler<CreateProjectCommand, int>
    {
        private readonly DevFreelancerDbContext _dbContext;
        public CreateProjectCommandHandler(DevFreelancerDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        //public async Task<int> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
        //{
        //    var project = new Project(request.Title, request.Description, request.IdClient, request.IdFreelancer, request.TotalCost);

        //    await _dbContext.Projects.AddAsync(project);
        //    await _dbContext.SaveChangesAsync();

        //    return project.Id;
        //}
    }
}
