using MediatR;

namespace DevFreelancer.Application.Commands.Users.UpdateUser
{
    public class UpdateUserCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public bool Active { get; set; }
    }
}
