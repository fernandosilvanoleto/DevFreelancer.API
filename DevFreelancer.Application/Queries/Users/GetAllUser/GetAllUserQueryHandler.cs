using DevFreelancer.Application.ViewModels;
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
        private readonly DevFreelancerDbContext _dbContext;
        public GetAllUserQueryHandler(DevFreelancerDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<UserViewAllModel>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
        {
            var users = _dbContext.Users;

            var userViewAllModel = await users
                .Select(u => new UserViewAllModel(u.FullName, u.Email, u.BirthDate, u.CreatedAt, u.Active))
                .ToListAsync();

            return userViewAllModel;
        }
    }
}
