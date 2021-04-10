using DevFreelancer.Application.Commands.Projects.CreateProject;
using DevFreelancer.Core.Entities;
using DevFreelancer.Core.Repositories;
using Moq;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace DevFreelancer.UnitTests.Application.Commands.Projects
{
    public class CreateProjectCommandHandlerTests
    {
        [Fact]
        public async Task InputDataIsOk_Executed_ReturnProjectId()
        {
            //Arrange
            var projectRepository = new Mock<IProjectRepository>();

            // LÁ DO COMMANDS => PROJECTS => CREATEPROJECT
            var createProjectCommand = new CreateProjectCommand
            {
                Title = "Título teste",
                Description = "Descrição teste",
                TotalCost = 5000,
                IdClient = 1,
                IdFreelancer = 2,
                FinishedAt = DateTime.Parse("2022-04-08")
            };

            var createProjectCommandHandler = new CreateProjectCommandHandler(projectRepository.Object);

            //Act
            var id = await createProjectCommandHandler.Handle(createProjectCommand, new CancellationToken());

            //Assert
            Assert.True(id >= 0);

            // VERIFICAR SE O MÉTODO DO REPOSITORY FOI CHAMADO
            // IsAny => PADRÃO PARA SABER SE O ENTITY PROJECT FOI CHAMADO UMA VEZ "ONCE"
            // It.IsAny<Project>()) É UMA SOBRECARGA LÁ NO REPOSITORY


        }
    }
}
