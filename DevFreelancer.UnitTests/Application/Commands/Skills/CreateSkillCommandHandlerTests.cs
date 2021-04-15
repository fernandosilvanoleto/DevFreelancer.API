using DevFreelancer.Application.Commands.Skills.CreateSkill;
using DevFreelancer.Core.Repositories;
using Moq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace DevFreelancer.UnitTests.Application.Commands.Skills
{
    public class CreateSkillCommandHandlerTests
    {
        [Fact]
        public async Task InputDataIsOk_Executed_ReturnSkillId()
        {
            //Arrange
            var skillRepository = new Mock<ISkillRepository>();

            var createSkillCommand = new CreateSkillCommand
            {
                Description = "Mentiroso"
            };

            var createSkillCommandHandler = new CreateSkillCommandHandler(skillRepository.Object);

            //Act
            var id = await createSkillCommandHandler.Handle(createSkillCommand, new CancellationToken());

            //Assert
            Assert.True(id >= 0);
        }
    }
}
