using DevFreelancer.Application.Commands.UserSkills.UserSkillCommand;
using DevFreelancer.Core.Repositories;
using Moq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace DevFreelancer.UnitTests.Application.Commands.UserSkills
{
    public class UserSkillCommandHandlerTests
    {
        [Fact]
        public async Task InputDataIsOk_Executed_ReturnUserSkillId()
        {
            // Arrange
            var userSkillRepository = new Mock<IUserSkillRepository>();

            var userSkillCommand = new UserSkillCommand
            {
                IdSkill = 1,
                IdUser = 1
            };

            var userSkillCommandHandler = new UserSkillCommandHandler(userSkillRepository.Object);

            // Act
            var id = await userSkillCommandHandler.Handle(userSkillCommand, new CancellationToken());


            // Assert
            Assert.True(id >= 0);
        }
    }
}
