using MediatR;

namespace DevFreelancer.Application.Commands.Projects.DeleteProject
{
    public class DeleteProjectCommand : IRequest<Unit>
    {
        // USEI UM CONSTRUTOR POR CAUSA DO CONTROLLER
        public DeleteProjectCommand(int id)
        {
            Id = id;
        }

        // UNIT => não tem o tipo de retorno
        public int Id { get; private set; }
    }
}
