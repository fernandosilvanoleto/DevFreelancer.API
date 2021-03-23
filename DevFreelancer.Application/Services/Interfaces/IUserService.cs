using DevFreelancer.Application.InputModels;
using DevFreelancer.Application.ViewModels;
using System.Collections.Generic;

namespace DevFreelancer.Application.Services.Interfaces
{
    public interface IUserService
    {
        UserViewModel GetUser(int id);
        List<UserViewAllModel> GetAll();
        int Create(CreateUserInputModel inputModel);
        void Update(UpdateUserInputModel inputModel);
    }
}
