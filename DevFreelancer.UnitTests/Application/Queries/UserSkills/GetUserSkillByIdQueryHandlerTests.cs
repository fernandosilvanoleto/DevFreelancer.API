using DevFreelancer.Application.Queries.UserSkill.GetUserSkillById;
using DevFreelancer.Core.Entities;
using DevFreelancer.Core.Repositories;
using Moq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace DevFreelancer.UnitTests.Application.Queries.UserSkills
{
    public class GetUserSkillByIdQueryHandlerTests
    {
        [Fact]
        public async Task ThreeProjectsExist_Executed_ReturnThreeUserSkillByIdViewModels()
        {
            // Arrange
            var userSkill = new UserSkill(1, 1);

            var userSkillRepository = new Mock<IUserSkillRepository>();
            userSkillRepository.Setup(uskill => uskill.GetByIdAsync(userSkill.Id).Result).Returns(userSkill);

            var getUserSkillByIdQuery = new GetUserSkillByIdQuery(userSkill.Id);
            var getUserSkillByIdQueryHandler = new GetUserSkillByIdQueryHandler(userSkillRepository.Object);

            // Act
            var userSkillViewModel = await getUserSkillByIdQueryHandler.Handle(getUserSkillByIdQuery, new CancellationToken());

            //Assert
            Assert.NotNull(userSkillViewModel);

            userSkillRepository.Verify(u => u.GetByIdAsync(userSkill.Id).Result, Times.Once);

        }
    }
}
