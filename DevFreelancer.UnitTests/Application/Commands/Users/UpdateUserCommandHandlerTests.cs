using DevFreelancer.Application.Commands.Users.UpdateUser;
using DevFreelancer.Core.Repositories;
using Moq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace DevFreelancer.UnitTests.Application.Commands.Users
{
    public class UpdateUserCommandHandlerTests
    {
        [Fact]
        public async Task InputDataIsOk_Executed_ReturnUser()
        {
            // Arrange
            var userRepository = new Mock<IUserRepository>();

            var updateUserCommand = new UpdateUserCommand
            {
                Id = 1,
                FullName = "Matheus",
                Email = "matheus@hotmail.com",
                Active = true
            };

            var updateUserCommandHandler = new UpdateUserCommandHandler(userRepository.Object);

            // Act
            await updateUserCommandHandler.Handle(updateUserCommand, new CancellationToken());

            // Assert
            userRepository.Verify(u => u.GetByIdAsync(updateUserCommand.Id), Times.Once);
            userRepository.Verify(u => u.SaveChangesAsync(), Times.Once);

        }
    }
}
