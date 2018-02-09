using HexagonalRealEstate.Domain.Accomodation;
using HexagonalRealEstate.Domain.AccomodationDomain;
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
            var accomodation = new Accomodation("A1");
            var accomodationRepository = Substitute.For<AccomodationRepository>();
            var service = new AccomodationServiceImpl(accomodationRepository);

            accomodationRepository.Exist(accomodation).Returns(false);

            //Action
            service.CreateAccomodation(accomodation);

            //Assert
            accomodationRepository.Received().Create(accomodation);
        }

        [Fact]
        public void CreateAccomodationShouldThrowExceptionWhenAccomodationAlreadyExist()
        {
            //Init
            var accomodation = new Accomodation("A1");
            var accomodationRepository = Substitute.For<AccomodationRepository>();
            var service = new AccomodationServiceImpl(accomodationRepository);

            accomodationRepository.Exist(accomodation).Returns(true);

            //Action
            //Assert
            Check.ThatCode(() => { service.CreateAccomodation(accomodation); })
                .Throws<AccomodationAlreadyExistException>();
        }
    }
}
