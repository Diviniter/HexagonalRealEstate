using System;
using HexagonalRealEstate.Domain.AccomodationDomain.Objects;
using HexagonalRealEstate.Domain.PersonDomain.Objects;
using HexagonalRealEstate.Domain.ProspectDomain.Objects;
using HexagonalRealEstate.Tests.Domain.AccomodationDomain;
using HexagonalRealEstate.Tests.Domain.PersonDomain;
using NFluent;
using Xunit;

namespace HexagonalRealEstate.Tests.Domain.ProspectDomain
{
    public class ProspectTest
    {
        private static Prospect GetProspect()
        {
            return new Prospect(PersonTest.GetPerson(), AccomodationTest.GetAccomodation());
        }

        [Fact]
        public void PersonPropertyShouldBeTheSameAsConstructorParameter()
        {
            var prospect = GetProspect();

            Check.That(prospect.Person).IsEqualTo(PersonTest.GetPerson());
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
            Check.ThatCode(() => { new Prospect(PersonTest.GetPerson(), accomodation); })
                .Throws<ArgumentNullException>();
        }

        [Fact]
        public void ProspectShouldNotAcceptNullPerson()
        {
            Person person = null;
            Check.ThatCode(() => { new Prospect(person, AccomodationTest.GetAccomodation()); })
                .Throws<ArgumentNullException>();
        }
    }
}
