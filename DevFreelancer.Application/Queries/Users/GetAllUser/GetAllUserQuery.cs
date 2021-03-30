using DevFreelancer.Application.ViewModels;
using MediatR;
using System.Collections.Generic;

namespace DevFreelancer.Application.Queries.Users.GetAllUser
{
    public class GetAllUserQuery : IRequest<List<UserViewAllModel>>
    {

    }
}
