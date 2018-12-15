using HexagonalRealEstate.Domain.AccomodationDomain.Exceptions;
using HexagonalRealEstate.Domain.AccomodationDomain.Objects;
using HexagonalRealEstate.Domain.AccomodationDomain.Repositories;
using HexagonalRealEstate.Domain.PersonDomain.Exceptions;
using HexagonalRealEstate.Domain.PersonDomain.Objects;
using HexagonalRealEstate.Domain.PersonDomain.Objects.Properties;
using HexagonalRealEstate.Domain.PersonDomain.Repositories;
using HexagonalRealEstate.Domain.ProspectDomain.Services;
using HexagonalRealEstate.Tests.Domain.AccomodationDomain;
using HexagonalRealEstate.Tests.Domain.PersonDomain;
using NFluent;
using NSubstitute;
using Optional;
using System;
using Xunit;

namespace HexagonalRealEstate.Tests.Domain.ProspectDomain
{
    public class ProspectServiceImplTest
    {
        public ProspectServiceImpl prospectService;
        public Person person;
        public Accomodation accomodation;
        public PersonRepository personRepository;
        public PersonQuery personQuery;
        public AccomodationQuery accomodationQuery;

        public ProspectServiceImplTest()
        {
            this.person = PersonTest.GetPerson(Option.None<PersonFirstName>(),
                Option.None<PersonName>(), Option.None<PersonEmail>());
            this.personRepository = Substitute.For<PersonRepository>();

            this.accomodation = AccomodationTest.GetAccomodation();

            this.personQuery = Substitute.For<PersonQuery>();
            this.personQuery.Exist(this.person).Returns(true);
            this.personQuery.IsProspectOnThisAccomodation(this.person, this.accomodation).Returns(false);

            this.accomodationQuery = Substitute.For<AccomodationQuery>();
            this.accomodationQuery.Exist(this.accomodation).Returns(true);

            this.prospectService = new ProspectServiceImpl(this.personRepository, this.personQuery, this.accomodationQuery);
        }

        [Fact]
        public void CreateProspectShouldCallRepository()
        {
            //Action
            this.prospectService.CreateProspect(this.person, this.accomodation);

            //Assert
            this.personRepository.Received().CreateProspect(this.person, this.accomodation);
        }

        [Fact]
        public void CreateProspectShouldThrowExceptionWhenPersonDoesNotExist()
        {
            //Init
            this.personQuery.Exist(this.person).Returns(false);

            //Act
            Action action = () => { this.prospectService.CreateProspect(this.person, this.accomodation); };

            //Assert
            Check.ThatCode(action).Throws<PersonDoesNotExistException>();
        }

        [Fact]
        public void CreateProspectShouldThrowExceptionWhenAccomodationDoesNotExist()
        {
            //Init
            this.accomodationQuery.Exist(this.accomodation).Returns(false);

            //Act
            Action action = () => { this.prospectService.CreateProspect(this.person, this.accomodation); };

            //Assert
            Check.ThatCode(action).Throws<AccomodationDoesNotExistException>();
        }
    }
}
