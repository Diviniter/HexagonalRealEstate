using HexagonalRealEstate.Domain.AccomodationDomain;
using HexagonalRealEstate.Domain.PersonDomain;
using HexagonalRealEstate.Domain.ProspectDomain;
using NFluent;
using System;
using Xunit;

namespace HexagonalRealEstate.Tests.Domain.ProspectDomain
{
    public class ProspectTest
    {
        [Fact]
        public void ProspectShouldBeEqualsToAPerson()
        {
            var prospect = new Prospect("Samantha", "De la licorne", "email@email.fr", new Accomodation("A201"));

            Check.That(prospect).Equals(new Person("Samantha", "De la licorne", "email@email.fr"));
        }

        [Fact]
        public void ProspectShouldNotAcceptNullAccomodation()
        {
            Accomodation accomodation = null;

            Check.ThatCode(() => { new Prospect("Samantha", "De la licorne", "email@email.fr", accomodation); })
                .Throws<ArgumentNullException>();
        }
    }
}
