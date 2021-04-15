using DevFreelancer.Application.Queries.ProjectComments.GetAllProjectComments;
using DevFreelancer.Core.Entities;
using DevFreelancer.Core.Repositories;
using Moq;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace DevFreelancer.UnitTests.Application.Queries.ProjectComments
{
    public class GetAllProjectCommentQueryHandlerTests
    {
        [Fact]
        public async Task ThreeProjectsExist_Executed_ReturnThreeProjectCommentViewModels()
        {
            //ASSERT
            var projectComments = new List<ProjectComment> { 
                new ProjectComment("Descrição teste", 1, 1),
                new ProjectComment("Descrição teste 1", 2, 2),
                new ProjectComment("Descrição teste 3", 3, 3)
            };

            var projectCommentRepositoryMock = new Mock<IProjectCommentRepository>();
            projectCommentRepositoryMock.Setup(pc => pc.GetAllProjectCommentsAsync().Result).Returns(projectComments);

            var getAllProjectCommentQuery = new GetAllProjectCommentQuery();
            var getAllProjectCommentQueryHandler = new GetAllProjectCommentQueryHandler(projectCommentRepositoryMock.Object);

            //Act
            var projectCommentViewAllModel = await getAllProjectCommentQueryHandler.Handle(getAllProjectCommentQuery, new CancellationToken());


            ////Assert
            //Assert.NotNull(projectCommentViewAllModel);
            //Assert.NotEmpty(projectCommentViewAllModel);
            //Assert.Equal(projectComment.Count, projectCommentViewAllModel.Count);

            //projectCommentRepositoryMock.Verify(pr => pr.GetAllProjectCommentsAsync().Result, Times.Once);

        }
    }
}
