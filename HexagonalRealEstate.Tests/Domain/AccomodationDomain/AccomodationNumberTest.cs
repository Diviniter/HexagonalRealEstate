using HexagonalRealEstate.Domain.AccomodationDomain.Objects.Properties;
using NFluent;
using Xunit;

namespace HexagonalRealEstate.Tests.Domain.AccomodationDomain
{
    public class AccomodationNumberTest
    {
        [Fact]
        public void ShouldBeginWithALetterFollowedByThreeNumbers()
        {
            var number = "A123";

            var accomodationNumber = AccomodationNumber.Create(number);

            Check.That(accomodationNumber.IsSuccess).IsTrue();
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("A1")]
        [InlineData("A12")]
        [InlineData("123A")]
        [InlineData(" A123")]
        [InlineData("A123 ")]
        [InlineData("AAAA")]
        [InlineData("1234")]
        [InlineData("A123A")]
        public void ShouldFailWhenNumberBeginWithALetterFollowedByThreeNumbers(string number)
        {
            var accomodation = AccomodationNumber.Create(number);

            Check.That(accomodation.IsFailure).IsTrue();
        }

        [Fact]
        public void ShouldBeEquals()
        {
            var number = "A123";

            var accomodationNumber = AccomodationNumber.Create(number).Value;
            var accomodationNumber2 = AccomodationNumber.Create(number).Value;

            Check.That(accomodationNumber).IsEqualTo(accomodationNumber2);
        }
    }
}
