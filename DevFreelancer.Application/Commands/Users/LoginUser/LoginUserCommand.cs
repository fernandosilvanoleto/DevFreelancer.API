using DevFreelancer.Application.ViewModels.User;
using MediatR;

namespace DevFreelancer.Application.Commands.Users.LoginUser
{
    public class LoginUserCommand : IRequest<LoginUserViewModel>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
