using System;

namespace HexagonalRealEstate.Domain.Accomodation
{
    public class AccomodationServiceImpl : AccomodationService
    {
        private readonly AccomodationRepository accomodationRepository;

        public AccomodationServiceImpl(AccomodationRepository accomodationRepository)
        {
            if (accomodationRepository == null)
                throw new ArgumentNullException(nameof(accomodationRepository));

            this.accomodationRepository = accomodationRepository;
        }

        public void CreateAccomodation(AccomodationDomain.Accomodation accomodation)
        {
            var exist = this.accomodationRepository.Exist(accomodation);
            if (exist)
                throw new AccomodationAlreadyExistException();

            this.accomodationRepository.Create(accomodation);
        }
    }
}
