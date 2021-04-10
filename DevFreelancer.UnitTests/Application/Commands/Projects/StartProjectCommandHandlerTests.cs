using DevFreelancer.Application.Commands.Projects.StartProject;
using DevFreelancer.Core.Repositories;
using Moq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace DevFreelancer.UnitTests.Application.Commands.Projects
{
    public class StartProjectCommandHandlerTests
    {
        [Fact]
        public async Task InputDataIsOk_Executed_StartProject()
        {
            //Arrange
            var projectRepository = new Mock<IProjectRepository>();

            // LÁ DO COMMANDS
            var startProjectCommand = new StartProjectCommand(1);

            var startProjectCommandHandler = new StartProjectCommandHandler(projectRepository.Object);

            //Act
            await startProjectCommandHandler.Handle(startProjectCommand, new CancellationToken());

            var project = await projectRepository.Object.GetByIdAsync(startProjectCommand.Id);

            //Assert
            projectRepository.Verify(pr => pr.StartAndSaveChangesAsync(project), Times.Once);
        }
    }
}
