using DevFreelancer.Application.ViewModels;
using DevFreelancer.Core.Repositories;
using DevFreelancer.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DevFreelancer.Application.Queries.Users.GetAllUser
{
    public class GetAllUserQueryHandler : IRequestHandler<GetAllUserQuery, List<UserViewAllModel>>
    {
        private readonly IUserRepository _userRepository;
        public GetAllUserQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<List<UserViewAllModel>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
        {
            var users = await _userRepository.GetAllAsync();

            var userViewAllModel = new List<UserViewAllModel>();

            //var userViewAllModel = users
            //    .Select(u => new UserViewAllModel(u.FullName, u.Email, u.BirthDate, u.CreatedAt, u.Active))
            //    .ToList();

            return userViewAllModel;
        }
    }
}
