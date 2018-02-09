using HexagonalRealEstate.Domain.Accomodation;
using HexagonalRealEstate.Domain.AccomodationDomain;
using HexagonalRealEstate.Domain.ClientDomain;
using HexagonalRealEstate.Domain.PersonDomain;
using HexagonalRealEstate.Domain.ProspectDomain;
using HexagonalRealEstate.Infrastructure.View;
using HexagonalRealEstate.Infrastructure.View.Models;
using NSubstitute;
using Xunit;

namespace HexagonalRealEstate.Tests.Infrastructure
{
    public class ControllerImplTest
    {
        [Fact]
        public void SellAccomodationShouldInformUserWhenAccomodationIsAlreadySold()
        {
            //Init
            var personModel = new PersonModel { FirstName = "O", Name = "A" };
            var accomodationModel = new AccomodationModel { Number = "A1" };

            var person = new Person("O", "A", "email@email.fr");
            var accomodation = new Accomodation("A1");
            var personService = Substitute.For<PersonService>();
            var clientService = Substitute.For<ClientService>();
            var prospectService = Substitute.For<ProspectService>();
            var writeStrategy = Substitute.For<WriteStrategy>();
            var accomodationRepository = Substitute.For<AccomodationRepository>();
            var accomodationService = Substitute.For<AccomodationService>();
            var personRepository = Substitute.For<PersonRepository>();
            var controller = new ControllerImpl(personService, clientService, prospectService,
                writeStrategy, accomodationRepository, accomodationService, personRepository);

            clientService
                .When(c => c.SellAccomodation(person, accomodation))
                .Do(c => { throw new AccomodationAlreadySold(); });

            //Action
            controller.SellAccomodation(personModel, accomodationModel);

            //Assert
            writeStrategy.Received().Write($"The accomodation({accomodationModel}) is already sold");
        }
    }
}
