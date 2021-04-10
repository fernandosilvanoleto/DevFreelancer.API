using DevFreelancer.Application.Commands.Projects.UpdateProject;
using DevFreelancer.Core.Entities;
using DevFreelancer.Core.Repositories;
using Moq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace DevFreelancer.UnitTests.Application.Commands.Projects
{
    public class UpdateProjectCommandHandlerTests
    {
        [Fact]
        public async Task InputDataIsOk_Executed_ReturnProject()
        {
            //Arrange
            var projectRepository = new Mock<IProjectRepository>();

            var updateProjectCommand = new UpdateProjectCommand
            {
                Id = 1,
                Title = "Título teste",
                Description = "Descrição teste",
                TotalCost = 5000
            };

            var updateProjectCommandHandler = new UpdateProjectCommandHandler(projectRepository.Object);

            //Act
            var id = await updateProjectCommandHandler.Handle(updateProjectCommand, new CancellationToken());

            // Assert
            projectRepository.Verify(pr => pr.SaveChangesAsync(), Times.Once);
        }
    }
}
