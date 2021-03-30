using DevFreelancer.Core.Entities;
using DevFreelancer.Infrastructure.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DevFreelancer.Application.Commands.ProjectComments.CreateComment
{
    public class CreateProjectCommentCommandHandler : IRequestHandler<CreateProjectCommentCommand, Unit>
    {
        private readonly DevFreelancerDbContext _dbContext;
        public CreateProjectCommentCommandHandler(DevFreelancerDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Unit> Handle(CreateProjectCommentCommand request, CancellationToken cancellationToken)
        {
            var projectComment = new ProjectComment(request.Content, request.IdProject, request.IdUser);

            await _dbContext.ProjectComments.AddAsync(projectComment);
            await _dbContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
