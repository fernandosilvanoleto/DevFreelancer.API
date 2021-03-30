using DevFreelancer.Infrastructure.Persistence;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DevFreelancer.Application.Commands.ProjectComments.UpdateComment
{
    public class UpdateProjectCommentCommandHandler : IRequestHandler<UpdateProjectCommentCommand, Unit>
    {
        private readonly DevFreelancerDbContext _dbContext;
        public UpdateProjectCommentCommandHandler(DevFreelancerDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Unit> Handle(UpdateProjectCommentCommand request, CancellationToken cancellationToken)
        {
            var projectComment = _dbContext.ProjectComments.SingleOrDefault(p => p.Id == request.Id);

            projectComment.Update(request.Content);
            await _dbContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
