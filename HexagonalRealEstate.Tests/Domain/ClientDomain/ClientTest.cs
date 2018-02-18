using System;
using HexagonalRealEstate.Domain.AccomodationDomain.Objects;
using HexagonalRealEstate.Domain.ClientDomain.Objects;
using HexagonalRealEstate.Domain.PersonDomain.Objects;
using HexagonalRealEstate.Tests.Domain.AccomodationDomain;
using HexagonalRealEstate.Tests.Domain.PersonDomain;
using NFluent;
using Xunit;

namespace HexagonalRealEstate.Tests.Domain.ClientDomain
{
    public class ClientTest
    {
        private static Client GetClient()
        {
            return new Client(PersonTest.GetPerson(), AccomodationTest.GetAccomodation());
        }

        [Fact]
        public void PersonPropertyShouldBeTheSameAsConstructorParameter()
        {
            var client = GetClient();

            Check.That(client.Person).IsEqualTo(PersonTest.GetPerson());
        }

        [Fact]
        public void AccomodationPropertyShouldBeTheSameAsConstructorParameter()
        {
            var client = GetClient();

            Check.That(client.Accomodation).IsEqualTo(AccomodationTest.GetAccomodation());
        }

        [Fact]
        public void ClientShouldNotAcceptNullAccomodation()
        {
            Accomodation accomodation = null;
            Check.ThatCode(() => { new Client(PersonTest.GetPerson(), accomodation); })
                .Throws<ArgumentNullException>();
        }

        [Fact]
        public void ClientShouldNotAcceptNullPerson()
        {
            Person person = null;
            Check.ThatCode(() => { new Client(person, AccomodationTest.GetAccomodation()); })
                .Throws<ArgumentNullException>();
        }
    }
}
