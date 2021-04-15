using DevFreelancer.Core.Entities;
using Xunit;

namespace DevFreelancer.UnitTests.Core.Entities
{
    public class UserTests
    {
        [Fact]
        public void TestIUserWorks()
        {
            var user = new User("Thiago Primo", "thiagoprimo@gmail.com", null, "-dpf!#14", "client");

            Assert.True(user.Active);

            Assert.NotNull(user.FullName);
            Assert.NotEmpty(user.FullName);

            Assert.NotNull(user.Email);
            Assert.NotEmpty(user.Email);

            Assert.NotNull(user.Password);
            Assert.NotEmpty(user.Password);
        }
    }
}
