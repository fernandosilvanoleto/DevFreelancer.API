using DevFreelancer.Application.Commands.Projects.FinishProject;
using DevFreelancer.Core.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace DevFreelancer.UnitTests.Application.Commands.Projects
{
    public class FinishProjectCommandHandlerTests
    {
        [Fact]
        public async Task InputDataIsOk_Executed_FinishedProject()
        {
            //Arrange
            var projectRepository = new Mock<IProjectRepository>();

            var finishProjectCommand = new FinishProjectCommand(1);

            var finishProjectCommandHandler = new FinishProjectCommandHandler(projectRepository.Object);

            //Act
            await finishProjectCommandHandler.Handle(finishProjectCommand, new CancellationToken());

            var project = await projectRepository.Object.GetByIdAsync(finishProjectCommand.Id);

            //Assert
            projectRepository.Verify(pr => pr.FinishAndSaveChangesAsync(project), Times.Once);

        }
    }
}
