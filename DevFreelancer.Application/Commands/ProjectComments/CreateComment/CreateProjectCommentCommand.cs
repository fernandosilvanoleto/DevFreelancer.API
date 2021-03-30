using MediatR;

namespace DevFreelancer.Application.Commands.ProjectComments.CreateComment
{
    public class CreateProjectCommentCommand : IRequest<Unit>
    {
        public string Content { get; set; }
        public int IdProject { get; set; }
        public int IdUser { get; set; }
    }
}
