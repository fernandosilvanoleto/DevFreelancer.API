using MediatR;

namespace DevFreelancer.Application.Commands.ProjectComments.UpdateComment
{
    public class UpdateProjectCommentCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string Content { get; set; }
    }
}
