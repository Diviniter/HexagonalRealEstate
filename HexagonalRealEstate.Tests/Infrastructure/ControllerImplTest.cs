using HexagonalRealEstate.Domain.AccomodationDomain.Exceptions;
using HexagonalRealEstate.Domain.AccomodationDomain.Service;
using HexagonalRealEstate.Domain.ClientDomain.Services;
using HexagonalRealEstate.Domain.PersonDomain.Services;
using HexagonalRealEstate.Domain.ProspectDomain.Services;
using HexagonalRealEstate.Infrastructure.Dependencies.DataAccessLayer.Repositories;
using HexagonalRealEstate.Infrastructure.View.Controllers;
using HexagonalRealEstate.Infrastructure.View.Models;
using HexagonalRealEstate.Tests.Domain.AccomodationDomain;
using HexagonalRealEstate.Tests.Domain.PersonDomain;
using NFluent;
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
            var clientModel = new SellAccomodationModel
            {
                AccomodationNumber = AccomodationTest.GetAccomodation().Number,
                PersonId = "1"
            };

            var person = PersonTest.GetPerson();
            var accomodation = AccomodationTest.GetAccomodation();
            var personService = Substitute.For<PersonService>();
            var clientService = Substitute.For<ClientService>();
            var prospectService = Substitute.For<ProspectService>();
            var accomodationService = Substitute.For<AccomodationService>();
            var personQuery = Substitute.For<PersonQueryExtended>();
            var accomodationQuery = Substitute.For<AccomodationQueryExtended>();
            var controller = new ControllerImpl(personService, clientService, prospectService,
                accomodationService, personQuery, accomodationQuery);

            clientService
                .When(c => c.SellAccomodation(person, accomodation))
                .Do(c => { throw new AccomodationAlreadySoldException(); });

            //Action
            var message = controller.SellAccomodation(clientModel);

            //Assert
            Check.That(message).IsEqualTo("Accomodation Sold !");
        }
    }
}
