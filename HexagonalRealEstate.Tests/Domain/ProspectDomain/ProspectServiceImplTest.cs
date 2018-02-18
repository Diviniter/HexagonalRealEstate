using HexagonalRealEstate.Domain.AccomodationDomain.Exceptions;
using HexagonalRealEstate.Domain.AccomodationDomain.Objects;
using HexagonalRealEstate.Domain.AccomodationDomain.Repositories;
using HexagonalRealEstate.Domain.PersonDomain.Exceptions;
using HexagonalRealEstate.Domain.PersonDomain.Objects;
using HexagonalRealEstate.Domain.PersonDomain.Repositories;
using HexagonalRealEstate.Domain.ProspectDomain.Services;
using HexagonalRealEstate.Tests.Domain.AccomodationDomain;
using HexagonalRealEstate.Tests.Domain.PersonDomain;
using NFluent;
using NSubstitute;
using Xunit;

namespace HexagonalRealEstate.Tests.Domain.ProspectDomain
{
    public class ProspectServiceImplTest
    {
        class ProspectServiceImplHelper
        {
            public ProspectServiceImpl ProspectServiceImpl;
            public Person Person;
            public Accomodation Accomodation;
            public PersonRepository PersonRepository;
            public PersonQuery PersonQuery;
            public AccomodationQuery AccomodationQuery;
        }

        private ProspectServiceImplHelper CreateProspectDefaultConfiguration()
        {
            var person = PersonTest.GetPerson();
            var personRepository = Substitute.For<PersonRepository>();

            var accomodation = AccomodationTest.GetAccomodation();

            var personQuery = Substitute.For<PersonQuery>();
            personQuery.Exist(person).Returns(true);
            personQuery.IsProspectOnThisAccomodation(person, accomodation).Returns(false);

            var accomodationQuery = Substitute.For<AccomodationQuery>();
            accomodationQuery.Exist(accomodation).Returns(true);

            var clientService = new ProspectServiceImpl(personRepository, personQuery, accomodationQuery);

            return new ProspectServiceImplHelper
            {
                Person = person,
                Accomodation = accomodation,
                PersonRepository = personRepository,
                PersonQuery = personQuery,
                AccomodationQuery = accomodationQuery,
                ProspectServiceImpl = clientService
            };
        }

        [Fact]
        public void CreateProspectShouldCallRepository()
        {
            //Init
            var defaultConfiguration = this.CreateProspectDefaultConfiguration();
            var person = defaultConfiguration.Person;
            var accomodation = defaultConfiguration.Accomodation;
            var prospectService = defaultConfiguration.ProspectServiceImpl;
            var personRepository = defaultConfiguration.PersonRepository;

            //Action
            prospectService.CreateProspect(person, accomodation);

            //Assert
            personRepository.Received().CreateProspect(person, accomodation);
        }

        [Fact]
        public void CreateProspectShouldThrowExceptionWhenPersonDoesNotExist()
        {
            //Init
            var defaultConfiguration = this.CreateProspectDefaultConfiguration();
            var person = defaultConfiguration.Person;
            var accomodation = defaultConfiguration.Accomodation;
            var prospectService = defaultConfiguration.ProspectServiceImpl;
            var personRepository = defaultConfiguration.PersonQuery;

            personRepository.Exist(person).Returns(false);

            //Action
            //Assert
            Check.ThatCode(() => { prospectService.CreateProspect(person, accomodation); })
                .Throws<PersonDoesNotExistException>();
        }

        [Fact]
        public void CreateProspectShouldThrowExceptionWhenAccomodationDoesNotExist()
        {
            //Init
            var defaultConfiguration = this.CreateProspectDefaultConfiguration();
            var person = defaultConfiguration.Person;
            var accomodation = defaultConfiguration.Accomodation;
            var prospectService = defaultConfiguration.ProspectServiceImpl;
            var accomodationQuery = defaultConfiguration.AccomodationQuery;

            accomodationQuery.Exist(accomodation).Returns(false);

            //Action
            //Assert
            Check.ThatCode(() => { prospectService.CreateProspect(person, accomodation); })
                .Throws<AccomodationDoesNotExistException>();
        }
    }
}
