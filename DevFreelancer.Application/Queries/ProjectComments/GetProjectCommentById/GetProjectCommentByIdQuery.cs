using DevFreelancer.Application.ViewModels.ProjectComment;
using MediatR;

namespace DevFreelancer.Application.Queries.ProjectComments.GetProjectCommentById
{
    public class GetProjectCommentByIdQuery : IRequest<ProjectCommentViewModel>
    {
        public GetProjectCommentByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
