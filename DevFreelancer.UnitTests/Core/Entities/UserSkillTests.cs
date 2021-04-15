using DevFreelancer.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DevFreelancer.UnitTests.Core.Entities
{
    public class UserSkillTests
    {
        [Fact]
        public void TestIUserSkillWorks()
        {
            var userSkill = new UserSkill(2, 2);

            Assert.NotNull(userSkill);
        }
    }
}
