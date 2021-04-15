using DevFreelancer.Core.Entities;
using Xunit;

namespace DevFreelancer.UnitTests.Core.Entities
{
    public class ProjectCommentTests
    {
        [Fact]
        public void TestIProjectCommentWorks()
        {
            var projectComment = new ProjectComment("Descricao Teste", 1, 2);

            Assert.NotNull(projectComment.Content);
            Assert.NotEmpty(projectComment.Content);

            Assert.NotNull(projectComment);
        }
    }
}
