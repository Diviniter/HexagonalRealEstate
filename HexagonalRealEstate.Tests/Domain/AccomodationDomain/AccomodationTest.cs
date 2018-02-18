using System;
using HexagonalRealEstate.Domain.AccomodationDomain.Objects;
using HexagonalRealEstate.Domain.AccomodationDomain.Objects.Properties;
using NFluent;
using Xunit;

namespace HexagonalRealEstate.Tests.Domain.AccomodationDomain
{
    public class AccomodationTest
    {
        public static Accomodation GetAccomodation()
        {
            var number = AccomodationNumber.Create("A100").Value;
            return new Accomodation(number);
        }

        [Fact]
        public void AccomodationShouldNotAcceptNullNumber()
        {
            Check.ThatCode(() => { new Accomodation(null); })
                .Throws<ArgumentNullException>();
        }

        [Fact]
        public void AccomodationShouldBeEquals()
        {
            var accomodation = GetAccomodation();
            var accomodation2 = GetAccomodation();

            Check.That(accomodation).IsEqualTo(accomodation2);
        }
    }
}
