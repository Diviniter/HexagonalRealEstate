using CSharpFunctionalExtensions;
using HexagonalRealEstate.Domain.AccomodationDomain.Exceptions;
using HexagonalRealEstate.Domain.AccomodationDomain.Objects;
using HexagonalRealEstate.Domain.AccomodationDomain.Repositories;
using HexagonalRealEstate.Domain.ClientDomain.Services;
using HexagonalRealEstate.Domain.PersonDomain.Exceptions;
using HexagonalRealEstate.Domain.PersonDomain.Objects;
using HexagonalRealEstate.Domain.PersonDomain.Objects.Properties;
using HexagonalRealEstate.Domain.PersonDomain.Repositories;
using HexagonalRealEstate.Domain.ProspectDomain.Services;
using HexagonalRealEstate.Tests.Domain.AccomodationDomain;
using NFluent;
using NSubstitute;
using Xunit;

namespace HexagonalRealEstate.Tests.Domain.ClientDomain
{
    public class ClientServiceImplTest
    {
        class ClientServiceImplHelper
        {
            public ClientServiceImpl ClientServiceImpl;
            public Person Person;
            public Accomodation Accomodation;
            public PersonRepository PersonRepository;
            public PersonQuery PersonQuery;
            public AccomodationRepository AccomodationRepository;
            public AccomodationQuery AccomodationQuery;
            public ProspectNotificationService ProspectNotificationService;
        }

        private ClientServiceImplHelper SellAccomodationDefaultConfiguration()
        {
            var person = new Person(
                Maybe<string>.None,
                PersonFirstName.Create("john").Value,
                PersonName.Create("smith").Value,
                PersonEmail.Create("email@email.fr").Value);
            var personQuery = Substitute.For<PersonQuery>();
            personQuery.Exist(person).Returns(true);

            var personRepository = Substitute.For<PersonRepository>();

            var accomodation = AccomodationTest.GetAccomodation();
            var accomodationRepository = Substitute.For<AccomodationRepository>();
            var accomodationQuery = Substitute.For<AccomodationQuery>();
            accomodationQuery.Exist(accomodation).Returns(true);
            personQuery.IsAccomodationSold(accomodation).Returns(false);

            var prospectNotificationService = Substitute.For<ProspectNotificationService>();

            var clientService = new ClientServiceImpl(personRepository, accomodationRepository,
                prospectNotificationService, personQuery, accomodationQuery);

            return new ClientServiceImplHelper
            {
                Person = person,
                Accomodation = accomodation,
                PersonRepository = personRepository,
                PersonQuery = personQuery,
                AccomodationRepository = accomodationRepository,
                AccomodationQuery = accomodationQuery,
                ProspectNotificationService = prospectNotificationService,
                ClientServiceImpl = clientService
            };
        }

        [Fact]
        public void SellAccomodationShouldCallRepository()
        {
            //Init
            var defaultConfiguration = this.SellAccomodationDefaultConfiguration();
            var person = defaultConfiguration.Person;
            var accomodation = defaultConfiguration.Accomodation;
            var personRepository = defaultConfiguration.PersonRepository;
            var clientService = defaultConfiguration.ClientServiceImpl;

            //Action
            clientService.SellAccomodation(person, accomodation);

            //Assert
            personRepository.Received().SellAccomodation(person, accomodation);
        }

        [Fact]
        public void SellAccomodationShouldThrowExceptionWhenPersonDoesNotExist()
        {
            //Init
            var defaultConfiguration = this.SellAccomodationDefaultConfiguration();
            var clientService = defaultConfiguration.ClientServiceImpl;
            var person = defaultConfiguration.Person;
            var accomodation = defaultConfiguration.Accomodation;
            var personQuery = defaultConfiguration.PersonQuery;

            personQuery.Exist(person).Returns(false);

            //Action
            //Assert
            Check.ThatCode(() => { clientService.SellAccomodation(person, accomodation); })
                .Throws<PersonDoesNotExistException>();
        }

        [Fact]
        public void SellAccomodationShouldThrowExceptionWhenAccomodationDoesNotExist()
        {
            //Init
            var defaultConfiguration = this.SellAccomodationDefaultConfiguration();
            var clientService = defaultConfiguration.ClientServiceImpl;
            var person = defaultConfiguration.Person;
            var accomodation = defaultConfiguration.Accomodation;
            var accomodationQuery = defaultConfiguration.AccomodationQuery;

            accomodationQuery.Exist(accomodation).Returns(false);

            //Action
            //Assert
            Check.ThatCode(() => { clientService.SellAccomodation(person, accomodation); })
                .Throws<AccomodationDoesNotExistException>();
        }

        [Fact]
        public void SellAccomodationShouldThrowExceptionWhenAccomodationIsAlreadySold()
        {
            //Init
            var defaultConfiguration = this.SellAccomodationDefaultConfiguration();
            var clientService = defaultConfiguration.ClientServiceImpl;
            var person = defaultConfiguration.Person;
            var accomodation = defaultConfiguration.Accomodation;
            var personQuery = defaultConfiguration.PersonQuery;

            personQuery.IsAccomodationSold(accomodation).Returns(true);

            //Action
            //Assert
            Check.ThatCode(() => { clientService.SellAccomodation(person, accomodation); })
                .Throws<AccomodationAlreadySoldException>();
        }

        [Fact]
        public void SellAccomodatioShouldNotifyProspectsWhenAccomodationIsSold()
        {
            //Init
            var defaultConfiguration = this.SellAccomodationDefaultConfiguration();
            var clientService = defaultConfiguration.ClientServiceImpl;
            var person = defaultConfiguration.Person;
            var accomodation = defaultConfiguration.Accomodation;
            var prospectNotificationService = defaultConfiguration.ProspectNotificationService;

            //Action
            clientService.SellAccomodation(person, accomodation);

            //Assert
            prospectNotificationService.Received().NotifyAccomodationIsNoMoreAvailable(accomodation);
        }
    }
}
