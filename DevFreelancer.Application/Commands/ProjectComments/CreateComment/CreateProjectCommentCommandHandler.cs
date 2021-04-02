using DevFreelancer.Core.Entities;
using DevFreelancer.Core.Repositories;
using DevFreelancer.Infrastructure.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DevFreelancer.Application.Commands.ProjectComments.CreateComment
{
    public class CreateProjectCommentCommandHandler : IRequestHandler<CreateProjectCommentCommand, Unit>
    {
        //private readonly DevFreelancerDbContext _dbContext;
        private readonly IProjectCommentRepository _projectCommentRepository;
        public CreateProjectCommentCommandHandler(IProjectCommentRepository projectCommentRepository)
        {
            _projectCommentRepository = projectCommentRepository;
        }
        public async Task<Unit> Handle(CreateProjectCommentCommand request, CancellationToken cancellationToken)
        {
            var projectComment = new ProjectComment(request.Content, request.IdProject, request.IdUser);

            await _projectCommentRepository.AddAsync(projectComment);

            return Unit.Value;
        }
    }
}
