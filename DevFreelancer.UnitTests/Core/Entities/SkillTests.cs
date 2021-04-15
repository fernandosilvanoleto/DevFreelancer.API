using DevFreelancer.Core.Entities;
using Xunit;

namespace DevFreelancer.UnitTests.Core.Entities
{
    public class SkillTests
    {
        [Fact]
        public void TestISkillWorks()
        {
            var skill = new Skill("Político");

            Assert.NotNull(skill.Description);
            Assert.NotEmpty(skill.Description);
        }
    }
}
