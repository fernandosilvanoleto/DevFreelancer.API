using DevFreelancer.Application.ViewModels;
using MediatR;

namespace DevFreelancer.Application.Queries.Users.GetUserById
{
    public class GetUserByIdQuery : IRequest<UserViewModel>
    {
        public GetUserByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
