﻿using DevFreelancer.Core.Entities;
using DevFreelancer.Core.Enums;
using System;
using Xunit;

namespace DevFreelancer.UnitTests.Core.Entities
{
    public class ProjectTests
    {
        [Fact]
        public void TestIProjectStartWorks()
        {
            var project = new Project("Nome de Teste", "Descricao de Teste", 1, 2, 10000, DateTime.Parse("2022-04-08"));

            Assert.Equal(ProjectStatusEnum.Created, project.Status);
            Assert.Null(project.StartedAt);

            Assert.NotNull(project.Title);
            Assert.NotEmpty(project.Title);

            Assert.NotNull(project.Description);
            Assert.NotEmpty(project.Description);

            project.Start();

            Assert.Equal(ProjectStatusEnum.InProgress, project.Status);
            Assert.NotNull(project.StartedAt);
        }
    }
}
