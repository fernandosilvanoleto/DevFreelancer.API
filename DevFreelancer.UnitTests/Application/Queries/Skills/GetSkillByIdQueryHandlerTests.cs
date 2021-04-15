using DevFreelancer.Application.Queries.Skills.GetSkillById;
using DevFreelancer.Core.Entities;
using DevFreelancer.Core.Repositories;
using Moq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace DevFreelancer.UnitTests.Application.Queries.Skills
{
    public class GetSkillByIdQueryHandlerTests
    {
        [Fact]
        public async Task ThreeProjectsExist_Executed_ReturnThreeSkillByIdViewModels()
        {
            // Arrange
            var skill = new Skill("Nome de Teste");

            var skillRepositoryMock = new Mock<ISkillRepository>();
            skillRepositoryMock.Setup(s => s.GetByIdAsync(skill.Id).Result).Returns(skill);


            var getSkillByIdQuery = new GetSkillByIdQuery(skill.Id);
            var getSkillByIdQueryHandler = new GetSkillByIdQueryHandler(skillRepositoryMock.Object);

            // Act
            var skillViewDetailsModel = await getSkillByIdQueryHandler.Handle(getSkillByIdQuery, new CancellationToken());

            // Assert
            Assert.NotNull(skillViewDetailsModel);

            skillRepositoryMock.Verify(s => s.GetByIdAsync(skill.Id).Result, Times.Once);

        }
    }
}
