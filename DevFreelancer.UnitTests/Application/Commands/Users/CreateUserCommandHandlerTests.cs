using DevFreelancer.Application.Commands.Users.CreateUser;
using DevFreelancer.Core.Repositories;
using DevFreelancer.Core.Services;
using Moq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace DevFreelancer.UnitTests.Application.Commands.Users
{
    public class CreateUserCommandHandlerTests
    {
        [Fact]
        public async Task InputDataIsOk_Executed_ReturnUserId()
        {
            // Arrange
            var userRepository = new Mock<IUserRepository>();
            var iAuthService = new Mock<IAuthService>();

            var createUserCommand = new CreateUserCommand 
            { 
                FullName = "Thiago Primo",
                Email = "thiagoprimo@gmail.com",
                Password = "-dpf!#14",
                Role = "client"
            };

            var createUserCommandHandler = new CreateUserCommandHandler(userRepository.Object, iAuthService.Object);

            // Act
            var id = await createUserCommandHandler.Handle(createUserCommand, new CancellationToken());

            // Assert
            Assert.True(id >= 0);
        }
    }
}
