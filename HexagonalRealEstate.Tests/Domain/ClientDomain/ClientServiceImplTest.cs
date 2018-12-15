using HexagonalRealEstate.Domain.AccomodationDomain.Exceptions;
using HexagonalRealEstate.Domain.AccomodationDomain.Objects;
using HexagonalRealEstate.Domain.AccomodationDomain.Repositories;
using HexagonalRealEstate.Domain.ClientDomain.Services;
using HexagonalRealEstate.Domain.PersonDomain.Exceptions;
using HexagonalRealEstate.Domain.PersonDomain.Objects;
using HexagonalRealEstate.Domain.PersonDomain.Objects.Properties;
using HexagonalRealEstate.Domain.PersonDomain.Repositories;
using HexagonalRealEstate.Tests.Domain.AccomodationDomain;
using MediatR;
using NFluent;
using NSubstitute;
using Optional;
using System;
using Xunit;

namespace HexagonalRealEstate.Tests.Domain.ClientDomain
{
    public class ClientServiceImplTest
    {
        private readonly ClientServiceImpl clientService;
        private readonly Person person;
        private readonly Accomodation accomodation;
        private readonly PersonRepository personRepository;
        private readonly PersonQuery personQuery;
        private readonly AccomodationQuery accomodationQuery;

        public ClientServiceImplTest()
        {
            this.person = new Person(
                Option.None<string>(),
                PersonFirstName.Create("john").Value,
                PersonName.Create("smith").Value,
                PersonEmail.Create("email@email.fr").Value);
            this.personQuery = Substitute.For<PersonQuery>();
            this.personQuery.Exist(this.person).Returns(true);

            var mediator = Substitute.For<IMediator>();
            this.personRepository = Substitute.For<PersonRepository>();

            this.accomodation = AccomodationTest.GetAccomodation();
            this.accomodationQuery = Substitute.For<AccomodationQuery>();
            this.accomodationQuery.Exist(this.accomodation).Returns(true);
            this.personQuery.IsAccomodationSold(this.accomodation).Returns(false);

            this.clientService = new ClientServiceImpl(this.personRepository,
                this.personQuery, this.accomodationQuery, mediator);
        }

        [Fact]
        public void Should_Add()
        {
            //Act
            this.clientService.SellAccomodation(this.person, this.accomodation);

            //Assert
            this.personRepository.Received().SellAccomodation(this.person, this.accomodation);
        }

        [Fact]
        public void SellAccomodationShouldThrowExceptionWhenPersonDoesNotExist()
        {
            //Init
            this.personQuery.Exist(this.person).Returns(false);

            //Act
            Action sellAccomodation = () => { this.clientService.SellAccomodation(this.person, this.accomodation); };

            //Assert
            Check.ThatCode(sellAccomodation).Throws<PersonDoesNotExistException>();
        }

        [Fact]
        public void SellAccomodationShouldThrowExceptionWhenAccomodationDoesNotExist()
        {
            //Init
            this.accomodationQuery.Exist(this.accomodation).Returns(false);

            //Act
            Action sellAccomodation = () => { this.clientService.SellAccomodation(this.person, this.accomodation); };

            //Assert
            Check.ThatCode(sellAccomodation).Throws<AccomodationDoesNotExistException>();
        }

        [Fact]
        public void SellAccomodationShouldThrowExceptionWhenAccomodationIsAlreadySold()
        {
            //Init
            this.personQuery.IsAccomodationSold(this.accomodation).Returns(true);

            //Act
            Action sellAccomodation = () => { this.clientService.SellAccomodation(this.person, this.accomodation); };

            //Assert
            Check.ThatCode(sellAccomodation).Throws<AccomodationAlreadySoldException>();
        }

        //TODO:How to test ?
        //[Fact]
        //public void SellAccomodatioShouldNotifyProspectsWhenAccomodationIsSold()
        //{
        //    //Init
        //    var defaultConfiguration = this.SellAccomodationDefaultConfiguration();
        //    var clientService = defaultConfiguration.ClientServiceImpl;
        //    var person = defaultConfiguration.Person;
        //    var accomodation = defaultConfiguration.Accomodation;

        //    //Action
        //    clientService.SellAccomodation(person, accomodation);

        //    //Assert
        //    prospectNotificationService.Received().NotifyAccomodationIsNoMoreAvailable(accomodation);
        //}
    }
}
