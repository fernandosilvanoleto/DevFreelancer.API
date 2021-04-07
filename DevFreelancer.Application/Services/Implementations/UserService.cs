using DevFreelancer.Application.InputModels;
using DevFreelancer.Application.Services.Interfaces;
using DevFreelancer.Application.ViewModels;
using DevFreelancer.Core.Entities;
using DevFreelancer.Infrastructure.Persistence;
using System.Collections.Generic;
using System.Linq;

namespace DevFreelancer.Application.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly DevFreelancerDbContext _dbContext;
        public UserService(DevFreelancerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int Create(CreateUserInputModel inputModel)
        {
            var user = new User(inputModel.FullName, inputModel.Email, inputModel.BirthDate, inputModel.Password, inputModel.Role);

            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();

            return user.Id;
        }

        public List<UserViewAllModel> GetAll()
        {
            var users = _dbContext.Users;

            var userViewAllModel = users
                .Select(u => new UserViewAllModel(u.FullName, u.Email, u.BirthDate, u.CreatedAt, u.Active))
                .ToList();

            return userViewAllModel;
        }

        public UserViewModel GetUser(int id)
        {
            var user = _dbContext.Users.SingleOrDefault(u => u.Id == id);

            if(user == null)
            {
                return null;
            }

            return new UserViewModel(user.FullName, user.Email);
        }

        public void Update(UpdateUserInputModel inputModel)
        {
            var user = _dbContext.Users.SingleOrDefault(u => u.Id == inputModel.Id);

            user.Update(inputModel.FullName, inputModel.Email, inputModel.Active);
            _dbContext.SaveChanges();
        }
    }
}
