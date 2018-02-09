using HexagonalRealEstate.Domain.AccomodationDomain;
using HexagonalRealEstate.Domain.ClientDomain;
using HexagonalRealEstate.Domain.PersonDomain;
using NFluent;
using System;
using Xunit;

namespace HexagonalRealEstate.Tests.Domain.ClientDomain
{
    public class ClientTest
    {
        [Fact]
        public void ClientShouldBeEqualsToAPerson()
        {
            var prospect = new Client("Samantha", "De la licorne", "email@email.fr", new Accomodation("A201"));

            Check.That(prospect).Equals(new Person("Samantha", "De la licorne", "email@email.fr"));
        }

        [Fact]
        public void ClientShouldNotAcceptNullAccomodation()
        {
            Accomodation accomodation = null;
            Check.ThatCode(() => { new Client("Samantha", "De la licorne", "email@email.fr", accomodation); })
                .Throws<ArgumentNullException>();
        }
    }
}
