using DevFreelancer.Application.ViewModels;
using MediatR;

namespace DevFreelancer.Application.Queries.Projects.GetProjectById
{
    public class GetProjectByIdQuery : IRequest<ProjectDetailsViewModel>
    {
        public GetProjectByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
