using DevFreelancer.Application.Queries.Users.GetAllUser;
using DevFreelancer.Core.Entities;
using DevFreelancer.Core.Repositories;
using Moq;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace DevFreelancer.UnitTests.Application.Queries.Users
{
    public class GetAllUserQueryHandlerTests
    {
        [Fact]
        public async Task ThreeProjectsExist_Executed_ReturnThreeUserAllViewModels()
        {
            // Arrange
            var users = new List<User>
            {
                new User("Thiago Primo", "thiagoprimo@gmail.com", null, "-dpf!#14", "client"),
                new User("Thiago Primo", "thiagoprimo@gmail.com", null, "-dpf!#14", "client"),
                new User("Thiago Primo", "thiagoprimo@gmail.com", null, "-dpf!#14", "client")
            };

            var userRepositoryMock = new Mock<IUserRepository>();
            userRepositoryMock.Setup(pr => pr.GetAllAsync().Result).Returns(users);

            var getAllUserQuery = new GetAllUserQuery();
            var getAllUserQueryHandler = new GetAllUserQueryHandler(userRepositoryMock.Object);

            //Act
            var userViewAllModel = await getAllUserQueryHandler.Handle(getAllUserQuery, new CancellationToken());

            //Assert
            Assert.NotNull(userViewAllModel);

            userRepositoryMock.Verify(pr => pr.GetAllAsync().Result, Times.Once);
        }
    }
}
