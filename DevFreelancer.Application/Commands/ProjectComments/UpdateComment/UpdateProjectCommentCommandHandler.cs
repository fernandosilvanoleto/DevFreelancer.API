using DevFreelancer.Core.Repositories;
using DevFreelancer.Infrastructure.Persistence;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DevFreelancer.Application.Commands.ProjectComments.UpdateComment
{
    public class UpdateProjectCommentCommandHandler : IRequestHandler<UpdateProjectCommentCommand, Unit>
    {
        //private readonly DevFreelancerDbContext _dbContext;
        private readonly IProjectCommentRepository _projectCommentRepository;
        public UpdateProjectCommentCommandHandler(IProjectCommentRepository projectCommentRepository)
        {
            _projectCommentRepository = projectCommentRepository;
        }
        public async Task<Unit> Handle(UpdateProjectCommentCommand request, CancellationToken cancellationToken)
        {
            var projectComment = await _projectCommentRepository.GetProjectCommentByIdAsync(request.Id);

            projectComment.Update(request.Content);

            await _projectCommentRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
