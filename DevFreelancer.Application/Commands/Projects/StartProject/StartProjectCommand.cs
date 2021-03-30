using MediatR;

namespace DevFreelancer.Application.Commands.Projects.StartProject
{
    public class StartProjectCommand : IRequest<Unit>
    {
        public StartProjectCommand(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
