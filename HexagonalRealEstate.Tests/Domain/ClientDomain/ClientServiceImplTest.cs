using HexagonalRealEstate.Domain.Accomodation;
using HexagonalRealEstate.Domain.AccomodationDomain;
using HexagonalRealEstate.Domain.ClientDomain;
using HexagonalRealEstate.Domain.General;
using HexagonalRealEstate.Domain.PersonDomain;
using HexagonalRealEstate.Domain.ProspectDomain;
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
            public AccomodationRepository AccomodationRepository;
            public ProspectNotificationService ProspectNotificationService;

        }

        private ClientServiceImplHelper SellAccomodationDefaultConfiguration()
        {
            var person = new Person("john", "smith", "email@email.fr");
            var personRepository = Substitute.For<PersonRepository>();
            personRepository.Exist(person).Returns(true);

            var accomodation = new Accomodation("A100");
            var accomodationRepository = Substitute.For<AccomodationRepository>();
            accomodationRepository.Exist(accomodation).Returns(true);
            personRepository.IsAccomodationSold(accomodation).Returns(false);

            var prospectNotificationService = Substitute.For<ProspectNotificationService>();

            var clientService = new ClientServiceImpl(personRepository, accomodationRepository, prospectNotificationService);

            return new ClientServiceImplHelper
            {
                Person = person,
                Accomodation = accomodation,
                PersonRepository = personRepository,
                AccomodationRepository = accomodationRepository,
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
            var personRepository = defaultConfiguration.PersonRepository;

            personRepository.Exist(person).Returns(false);

            //Action
            //Assert
            Check.ThatCode(() => { clientService.SellAccomodation(person, accomodation); })
                .Throws<ObjectDoesNotExistInRepositoryException>();
        }

        [Fact]
        public void SellAccomodationShouldThrowExceptionWhenAccomodationDoesNotExist()
        {
            //Init
            var defaultConfiguration = this.SellAccomodationDefaultConfiguration();
            var clientService = defaultConfiguration.ClientServiceImpl;
            var person = defaultConfiguration.Person;
            var accomodation = defaultConfiguration.Accomodation;
            var accomodationRepository = defaultConfiguration.AccomodationRepository;

            accomodationRepository.Exist(accomodation).Returns(false);

            //Action
            //Assert
            Check.ThatCode(() => { clientService.SellAccomodation(person, accomodation); })
                .Throws<ObjectDoesNotExistInRepositoryException>();
        }

        [Fact]
        public void SellAccomodationShouldThrowExceptionWhenAccomodationIsAlreadySold()
        {
            //Init
            var defaultConfiguration = this.SellAccomodationDefaultConfiguration();
            var clientService = defaultConfiguration.ClientServiceImpl;
            var person = defaultConfiguration.Person;
            var accomodation = defaultConfiguration.Accomodation;
            var personRepository = defaultConfiguration.PersonRepository;

            personRepository.IsAccomodationSold(accomodation).Returns(true);

            //Action
            //Assert
            Check.ThatCode(() => { clientService.SellAccomodation(person, accomodation); })
                .Throws<AccomodationAlreadySold>();
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
