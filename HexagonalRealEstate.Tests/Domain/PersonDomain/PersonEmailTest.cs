using HexagonalRealEstate.Domain.PersonDomain.Objects.Properties;
using NFluent;
using Xunit;

namespace HexagonalRealEstate.Tests.Domain.PersonDomain
{
    public class PersonEmailTest
    {
        [Fact]
        public void EmailShouldHaveEmailFormat()
        {
            var stringEmail = "test@test.fr";
            var email = PersonEmail.Create(stringEmail);
            Check.That<string>(email.Value.Value).IsEqualTo("test@test.fr");
        }

        [Theory]
        [InlineData("t")]
        [InlineData("t@")]
        [InlineData("t@t")]
        [InlineData("t@t.")]
        [InlineData("t@t.t")]
        [InlineData("1t@t.t")]
        [InlineData("1t@t.tr.")]
        public void EmailShouldNotHaveAnotherFormatThanEmail(string invalidEmail)
        {
            var email = PersonEmail.Create(invalidEmail);
            Check.That(email.IsFailure).IsTrue();
        }

        [Fact]
        public void EmailShouldCanBeEmpty()
        {
            var stringEmail = "";
            var email = PersonEmail.Create(stringEmail);
            Check.That(email.IsSuccess).IsTrue();
        }

        [Fact]
        public void EmailShouldBeEqualsToSameEmail()
        {
            var stringEmail = "";
            var email = PersonEmail.Create(stringEmail).Value;
            var email2 = PersonEmail.Create(stringEmail).Value;

            Check.That(email).IsEqualTo(email2);
        }
    }
}
