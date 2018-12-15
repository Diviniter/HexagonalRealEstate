using HexagonalRealEstate.Domain.AccomodationDomain.Exceptions;
using HexagonalRealEstate.Domain.AccomodationDomain.Objects;
using HexagonalRealEstate.Domain.AccomodationDomain.Repositories;

namespace HexagonalRealEstate.Domain.AccomodationDomain.Service
{
    public class AccomodationServiceImpl : AccomodationService
    {
        private readonly AccomodationQuery accomodationQuery;
        private readonly AccomodationRepository accomodationRepository;

        public AccomodationServiceImpl(AccomodationRepository accomodationRepository, AccomodationQuery accomodationQuery)
        {
            this.accomodationRepository = accomodationRepository;
            this.accomodationQuery = accomodationQuery;
        }

        public void CreateAccomodation(Accomodation accomodation)
        {
            var exist = this.accomodationQuery.Exist(accomodation);
            if (exist)
                throw new AccomodationAlreadyExistException();

            this.accomodationRepository.Create(accomodation);
        }
    }
}
