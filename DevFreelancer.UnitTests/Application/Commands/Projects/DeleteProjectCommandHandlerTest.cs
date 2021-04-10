using DevFreelancer.Application.Commands.Projects.DeleteProject;
using DevFreelancer.Core.Entities;
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
    public class DeleteProjectCommandHandlerTest
    {
        [Fact]
        public async Task InputDataIsOk_Executed_DeleteProject()
        {
            //Arrange
            var projectRepository = new Mock<IProjectRepository>();

            // LÁ DO COMMANDS
            var deleteProjectCommand = new DeleteProjectCommand(1);

            var deleteProjectCommandHandler = new DeleteProjectCommandHandler(projectRepository.Object);

            //Act
            await deleteProjectCommandHandler.Handle(deleteProjectCommand, new CancellationToken());

            var project = await projectRepository.Object.GetByIdAsync(deleteProjectCommand.Id);

            //await projectRepository.Object.SaveChangesAsync();

            ////Assert
            projectRepository.Verify(pr => pr.DeleteAndSaveChangesAsync(project), Times.Once);
        }
    }
}
