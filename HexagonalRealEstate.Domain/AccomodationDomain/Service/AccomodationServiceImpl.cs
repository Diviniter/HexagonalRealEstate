using System;
using HexagonalRealEstate.Domain.AccomodationDomain.Exceptions;
using HexagonalRealEstate.Domain.AccomodationDomain.Objects;
using HexagonalRealEstate.Domain.AccomodationDomain.Repositories;

namespace HexagonalRealEstate.Domain.AccomodationDomain.Service
{
    public class AccomodationServiceImpl : AccomodationService
    {
        public readonly AccomodationQuery AccomodationQuery;
        private readonly AccomodationRepository accomodationRepository;

        public AccomodationServiceImpl(AccomodationRepository accomodationRepository, AccomodationQuery accomodationQuery)
        {
            if (accomodationRepository == null)
                throw new ArgumentNullException(nameof(accomodationRepository));
            if (accomodationQuery == null)
                throw new ArgumentNullException(nameof(accomodationQuery));

            this.accomodationRepository = accomodationRepository;
            this.AccomodationQuery = accomodationQuery;

        }

        public void CreateAccomodation(Accomodation accomodation)
        {
            var exist = this.AccomodationQuery.Exist(accomodation);
            if (exist)
                throw new AccomodationAlreadyExistException();

            this.accomodationRepository.Create(accomodation);
        }
    }
}
