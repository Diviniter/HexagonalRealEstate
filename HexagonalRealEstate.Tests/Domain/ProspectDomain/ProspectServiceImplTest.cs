using HexagonalRealEstate.Domain.Accomodation;
using HexagonalRealEstate.Domain.AccomodationDomain;
using HexagonalRealEstate.Domain.General;
using HexagonalRealEstate.Domain.PersonDomain;
using HexagonalRealEstate.Domain.ProspectDomain;
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
            public HexagonalRealEstate.Domain.PersonDomain.Person Person;
            public Accomodation Accomodation;
            public PersonRepository PersonRepository;
            public AccomodationRepository AccomodationRepository;
        }

        private ProspectServiceImplHelper SetPersonAsProspectDefaultConfiguration()
        {
            var person = new HexagonalRealEstate.Domain.PersonDomain.Person("john", "smith", "email@email.fr");
            var personRepository = Substitute.For<PersonRepository>();
            personRepository.Exist(person).Returns(true);

            var accomodation = new Accomodation("A100");
            var accomodationRepository = Substitute.For<AccomodationRepository>();
            accomodationRepository.Exist(accomodation).Returns(true);

            var clientService = new ProspectServiceImpl(personRepository, accomodationRepository);

            return new ProspectServiceImplHelper
            {
                Person = person,
                Accomodation = accomodation,
                PersonRepository = personRepository,
                AccomodationRepository = accomodationRepository,
                ProspectServiceImpl = clientService
            };
        }

        [Fact]
        public void SetPersonAsProspectShouldCallRepository()
        {
            //Init
            var defaultConfiguration = this.SetPersonAsProspectDefaultConfiguration();
            var person = defaultConfiguration.Person;
            var accomodation = defaultConfiguration.Accomodation;
            var prospectService = defaultConfiguration.ProspectServiceImpl;
            var personRepository = defaultConfiguration.PersonRepository;

            //Action
            prospectService.SetPersonAsProspect(person, accomodation);

            //Assert
            personRepository.Received().SetPersonAsProspect(person, accomodation);
        }

        [Fact]
        public void SetPersonAsProspectShouldThrowExceptionWhenPersonDoesNotExist()
        {
            //Init
            var defaultConfiguration = this.SetPersonAsProspectDefaultConfiguration();
            var person = defaultConfiguration.Person;
            var accomodation = defaultConfiguration.Accomodation;
            var prospectService = defaultConfiguration.ProspectServiceImpl;
            var personRepository = defaultConfiguration.PersonRepository;

            personRepository.Exist(person).Returns(false);

            //Action
            //Assert
            Check.ThatCode(() => { prospectService.SetPersonAsProspect(person, accomodation); })
                .Throws<ObjectDoesNotExistInRepositoryException>();
        }

        [Fact]
        public void SetPersonAsProspectShouldThrowExceptionWhenAccomodationDoesNotExist()
        {
            //Init
            var defaultConfiguration = this.SetPersonAsProspectDefaultConfiguration();
            var person = defaultConfiguration.Person;
            var accomodation = defaultConfiguration.Accomodation;
            var prospectService = defaultConfiguration.ProspectServiceImpl;
            var accomodationRepository = defaultConfiguration.AccomodationRepository;

            accomodationRepository.Exist(accomodation).Returns(false);

            //Action
            //Assert
            Check.ThatCode(() => { prospectService.SetPersonAsProspect(person, accomodation); })
                .Throws<ObjectDoesNotExistInRepositoryException>();
        }
    }
}
