using HexagonalRealEstate.Domain.AccomodationDomain.Objects;
using HexagonalRealEstate.Domain.ClientDomain.Objects;
using HexagonalRealEstate.Domain.PersonDomain.Objects;
using HexagonalRealEstate.Tests.Domain.AccomodationDomain;
using HexagonalRealEstate.Tests.Domain.PersonDomain;
using NFluent;
using System;
using Xunit;

namespace HexagonalRealEstate.Tests.Domain.ClientDomain
{
    public class ClientTest
    {
        private readonly Client client;

        public ClientTest()
        {
            var person = PersonTest.GetPersonWithoutId();
            this.client = new Client(person, AccomodationTest.GetAccomodation());
        }

        [Fact]
        public void PersonPropertyShouldBeTheSameAsConstructorParameter()
        {
            Check.That(this.client.Person).IsEqualTo(PersonTest.GetPersonWithoutId());
        }

        [Fact]
        public void AccomodationPropertyShouldBeTheSameAsConstructorParameter()
        {
            Check.That(this.client.Accomodation).IsEqualTo(AccomodationTest.GetAccomodation());
        }

        [Fact]
        public void ClientShouldNotAcceptNullAccomodation()
        {
            Accomodation accomodation = null;

            Action action = () => new Client(PersonTest.GetPersonWithoutId(), accomodation);

            Check.ThatCode(action).Throws<ArgumentNullException>();
        }

        [Fact]
        public void ClientShouldNotAcceptNullPerson()
        {
            Person person = null;

            Action action = () => new Client(person, AccomodationTest.GetAccomodation());

            Check.ThatCode(action).Throws<ArgumentNullException>();
        }
    }
}
