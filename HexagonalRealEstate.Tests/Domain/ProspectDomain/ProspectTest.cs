using HexagonalRealEstate.Domain.AccomodationDomain.Objects;
using HexagonalRealEstate.Domain.PersonDomain.Objects;
using HexagonalRealEstate.Domain.ProspectDomain.Objects;
using HexagonalRealEstate.Tests.Domain.AccomodationDomain;
using HexagonalRealEstate.Tests.Domain.PersonDomain;
using NFluent;
using System;
using Xunit;

namespace HexagonalRealEstate.Tests.Domain.ProspectDomain
{
    public class ProspectTest
    {
        private static Prospect GetProspect()
        {
            return new Prospect(PersonTest.GetPersonWithoutId(), AccomodationTest.GetAccomodation());
        }

        [Fact]
        public void PersonPropertyShouldBeTheSameAsConstructorParameter()
        {
            var prospect = GetProspect();

            Check.That(prospect.Person).IsEqualTo(PersonTest.GetPersonWithoutId());
        }

        [Fact]
        public void AccomodationPropertyShouldBeTheSameAsConstructorParameter()
        {
            var prospect = GetProspect();

            Check.That(prospect.Accomodation).IsEqualTo(AccomodationTest.GetAccomodation());
        }

        [Fact]
        public void ProspectShouldNotAcceptNullAccomodation()
        {
            Accomodation accomodation = null;

            Action action = () => { new Prospect(PersonTest.GetPersonWithoutId(), accomodation); };

            Check.ThatCode(action).Throws<ArgumentNullException>();
        }

        [Fact]
        public void ProspectShouldNotAcceptNullPerson()
        {
            Person person = null;

            Action action = () => { new Prospect(person, AccomodationTest.GetAccomodation()); };

            Check.ThatCode(action).Throws<ArgumentNullException>();
        }
    }
}
