using DevFreelancer.Application.Queries.Projects.GetProjectById;
using DevFreelancer.Core.Entities;
using DevFreelancer.Core.Repositories;
using Moq;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace DevFreelancer.UnitTests.Application.Queries.Projects
{
    public class GetProjectByIdQueryHandlerTests
    {
        [Fact]
        public async Task ThreeProjectsExist_Executed_ReturnThreeProjectByIdViewModels()
        {
            // CRIAR UM PROJETO
            // Arrange
            var project = new Project("Nome de Teste", "Descricao de Teste", 1, 2, 10000, DateTime.Parse("2022-04-08"));

            var projectRepositoryMock = new Mock<IProjectRepository>();
            projectRepositoryMock.Setup(pr => pr.GetByIdAsync(project.Id).Result).Returns(project);

            var getProjectByIdQuery = new GetProjectByIdQuery(project.Id);
            var getProjectByIdQueryHandler = new GetProjectByIdQueryHandler(projectRepositoryMock.Object);

            // Act
            var projectViewModel = await getProjectByIdQueryHandler.Handle(getProjectByIdQuery, new CancellationToken());

            //Assert
            Assert.NotNull(projectViewModel);

            projectRepositoryMock.Verify(pr => pr.GetByIdAsync(project.Id).Result, Times.Once);
        }
    }
}
