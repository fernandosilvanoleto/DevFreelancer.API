using DevFreelancer.Application.Commands.ProjectComments.UpdateComment;
using DevFreelancer.Core.Repositories;
using Moq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace DevFreelancer.UnitTests.Application.Commands.ProjectComments
{
    public class UpdateProjectCommentCommandHandlerTests
    {
        [Fact]
        public async Task InputDataIsOk_Executed_ReturnProjectComment()
        {
            //Arrange
            var projectCommentRepository = new Mock<IProjectCommentRepository>();

            var updateProjectCommentCommand = new UpdateProjectCommentCommand
            {
                Id = 1,
                Content = "Descrição teste"
            };

            var updateProjectCommentCommandHandler = new UpdateProjectCommentCommandHandler(projectCommentRepository.Object);

            //Act
            await updateProjectCommentCommandHandler.Handle(updateProjectCommentCommand, new CancellationToken());

            //Assert
            projectCommentRepository.Verify(pr => pr.SaveChangesAsync(), Times.Once);
        }
    }
}
