using DevFreelancer.Application.Queries.ProjectComments.GetProjectCommentById;
using DevFreelancer.Core.Entities;
using DevFreelancer.Core.Repositories;
using Moq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace DevFreelancer.UnitTests.Application.Queries.ProjectComments
{
    public class GetProjectCommentByIdQueryHandlerTests
    {
        [Fact]
        public async Task ThreeProjectsExist_Executed_ReturnThreeProjectCommentByIdViewModels()
        {
            // Arrange
            var projectComment = new ProjectComment("Descrição teste", 1, 1);

            var projectCommentRepositoryMock = new Mock<IProjectCommentRepository>();
            projectCommentRepositoryMock.Setup(pc => pc.GetProjectCommentByIdAsync(projectComment.Id).Result).Returns(projectComment);

            var getProjectCommentByIdQuery = new GetProjectCommentByIdQuery(projectComment.Id);
            var getProjectCommentByIdQueryHandler = new GetProjectCommentByIdQueryHandler(projectCommentRepositoryMock.Object);


            // ACT
            var projectCommentViewModel = await getProjectCommentByIdQueryHandler.Handle(getProjectCommentByIdQuery, new CancellationToken());


            // Assert
            Assert.NotNull(projectCommentViewModel);

            projectCommentRepositoryMock.Verify(pc => pc.GetProjectCommentByIdAsync(projectComment.Id).Result, Times.Once);

        }
    }
}
