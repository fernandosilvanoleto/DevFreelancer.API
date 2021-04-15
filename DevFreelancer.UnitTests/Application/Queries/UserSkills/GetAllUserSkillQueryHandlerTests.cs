using DevFreelancer.Application.Queries.UserSkill.GetAllUserSkill;
using DevFreelancer.Core.Entities;
using DevFreelancer.Core.Repositories;
using Moq;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace DevFreelancer.UnitTests.Application.Queries.UserSkills
{
    public class GetAllUserSkillQueryHandlerTests
    {
        [Fact]
        public async Task ThreeProjectsExist_Executed_ReturnThreeUserSkillAllViewModels()
        {
            // Arrange
            var userSkills = new List<UserSkill>
            {
                new UserSkill(1, 1),
                new UserSkill(2, 2),
                new UserSkill(2, 2)
            };

            var userSkillRepository = new Mock<IUserSkillRepository>();
            userSkillRepository.Setup(pr => pr.GetAllAsync().Result).Returns(userSkills);

            var getAllUserSkillQuery = new GetAllUserSkillQuery();
            var getAllUserSkillQueryHandler = new GetAllUserSkillQueryHandler(userSkillRepository.Object);

            //Act
            var userSkillViewAllModel = await getAllUserSkillQueryHandler.Handle(getAllUserSkillQuery, new CancellationToken());

            //Assert
            Assert.NotNull(userSkillViewAllModel);

            userSkillRepository.Verify(pr => pr.GetAllAsync().Result, Times.Once);
        }
    }
}
