using HexagonalRealEstate.Domain.AccomodationDomain;
using NFluent;
using System;
using Xunit;

namespace HexagonalRealEstate.Tests.Domain.AccomodationDomain
{
    public class AccomodationTest
    {
        [Fact]
        public void AccomodationShouldNotAcceptEmptyNumber()
        {
            Check.ThatCode(() => { new Accomodation(""); })
                .Throws<ArgumentNullException>();
        }

        [Fact]
        public void AccomodationShouldNotAcceptNullNumber()
        {
            Check.ThatCode(() => { new Accomodation(null); })
                .Throws<ArgumentNullException>();
        }
    }
}
