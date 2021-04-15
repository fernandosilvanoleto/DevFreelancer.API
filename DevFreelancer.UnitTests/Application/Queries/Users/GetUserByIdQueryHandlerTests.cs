using DevFreelancer.Application.Queries.Users.GetUserById;
using DevFreelancer.Core.Entities;
using DevFreelancer.Core.Repositories;
using Moq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace DevFreelancer.UnitTests.Application.Queries.Users
{
    public class GetUserByIdQueryHandlerTests
    {
        [Fact]
        public async Task ThreeProjectsExist_Executed_ReturnThreeUserByIdViewModels()
        {
            // Arrange
            var user = new User("Thiago Primo", "thiagoprimo@gmail.com", null, "-dpf!#14", "client");

            var userRepositoryMock = new Mock<IUserRepository>();
            userRepositoryMock.Setup(u => u.GetByIdAsync(user.Id).Result).Returns(user);

            var getUserByIdQuery = new GetUserByIdQuery(user.Id);
            var getUserByIdQueryHandler = new GetUserByIdQueryHandler(userRepositoryMock.Object);

            // Act
            var userViewModel = await getUserByIdQueryHandler.Handle(getUserByIdQuery, new CancellationToken());

            //Assert
            Assert.NotNull(userViewModel);

            userRepositoryMock.Verify(u => u.GetByIdAsync(user.Id).Result, Times.Once);
        }
    }
}
