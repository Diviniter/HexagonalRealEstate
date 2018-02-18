using HexagonalRealEstate.Domain.AccomodationDomain.Exceptions;
using HexagonalRealEstate.Domain.AccomodationDomain.Repositories;
using HexagonalRealEstate.Domain.AccomodationDomain.Service;
using NFluent;
using NSubstitute;
using Xunit;

namespace HexagonalRealEstate.Tests.Domain.AccomodationDomain
{
    public class AccomodationServiceImplTest
    {
        [Fact]
        public void CreateAccomodationShouldCallRepository()
        {
            //Init
            var accomodation = AccomodationTest.GetAccomodation();
            var accomodationQuery = Substitute.For<AccomodationQuery>();
            var accomodationRepository = Substitute.For<AccomodationRepository>();
            var service = new AccomodationServiceImpl(accomodationRepository, accomodationQuery);

            accomodationQuery.Exist(accomodation).Returns(false);

            //Action
            service.CreateAccomodation(accomodation);

            //Assert
            accomodationRepository.Received().Create(accomodation);
        }

        [Fact]
        public void CreateAccomodationShouldThrowExceptionWhenAccomodationAlreadyExist()
        {
            //Init
            var accomodation = AccomodationTest.GetAccomodation();
            var accomodationQuery = Substitute.For<AccomodationQuery>();
            var accomodationRepository = Substitute.For<AccomodationRepository>();
            var service = new AccomodationServiceImpl(accomodationRepository, accomodationQuery);

            accomodationQuery.Exist(accomodation).Returns(true);

            //Action
            //Assert
            Check.ThatCode(() => { service.CreateAccomodation(accomodation); })
                .Throws<AccomodationAlreadyExistException>();
        }
    }
}
