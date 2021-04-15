using DevFreelancer.Application.Commands.ProjectComments.CreateComment;
using DevFreelancer.Core.Entities;
using DevFreelancer.Core.Repositories;
using Moq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace DevFreelancer.UnitTests.Application.Commands.ProjectComments
{
    public class CreateProjectCommentCommandHandlerTests
    {
        [Fact]
        public async Task InputDataIsOk_Executed_ReturnProjecCommenttId()
        {
            //Arrange
            var projectCommentRepository = new Mock<IProjectCommentRepository>();

            // LÁ DO COMMANDS => PROJECTS => CREATEPROJECT
            var createProjectCommentCommand = new CreateProjectCommentCommand
            {
                Content = "Descrição teste",
                IdProject = 1,
                IdUser = 1
            };

            var createProjectCommentCommandHandler = new CreateProjectCommentCommandHandler(projectCommentRepository.Object);

            //Act
            await createProjectCommentCommandHandler.Handle(createProjectCommentCommand, new CancellationToken());

            //Assert
            projectCommentRepository.Verify(p => p.AddAsync(It.IsAny<ProjectComment>()), Times.Once);
        }
    }
}
