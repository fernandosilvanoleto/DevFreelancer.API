using DevFreelancer.Application.Queries.Projects.GetAllProjects;
using DevFreelancer.Core.Entities;
using DevFreelancer.Core.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace DevFreelancer.UnitTests.Application.Queries.Projects
{
    public class GetAllProjectQueryHandlerTests
    {
        [Fact]
        public async Task ThreeProjectsExist_Executed_ReturnThreeProjectViewModels()
        {
            // ANTES, INSTALA O PACOTE MOQ NO NUGETS
            // Arrange
            var projects = new List<Project>
            {
                new Project("Nome de Teste 1", "Descricao de Teste ", 1, 2, 10000, DateTime.Parse("2022-04-08")),
                new Project("Nome de Teste 2", "Descricao de Teste 2", 1, 2, 20000, DateTime.Parse("2022-04-08")),
                new Project("Nome de Teste 3", "Descricao de Teste 3", 1, 2, 30000, DateTime.Parse("2022-04-08"))
            };

            var projectRepositoryMock = new Mock<IProjectRepository>();
            projectRepositoryMock.Setup(pr => pr.GetAllAsync().Result).Returns(projects);

            var getAllProjectQuery = new GetAllProjectQuery("");
            var getAllProjectQueryHandler = new GetAllProjectQueryHandler(projectRepositoryMock.Object);

            //Act
            var projectViewModelList = await getAllProjectQueryHandler.Handle(getAllProjectQuery, new CancellationToken());

            //Assert
            Assert.NotNull(projectViewModelList);
            Assert.NotEmpty(projectViewModelList);
            Assert.Equal(projects.Count, projectViewModelList.Count);

            projectRepositoryMock.Verify(pr => pr.GetAllAsync().Result, Times.Once);

        }
    }
}
