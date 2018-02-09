using HexagonalRealEstate.Domain.Accomodation;
using HexagonalRealEstate.Domain.General;
using HexagonalRealEstate.Domain.PersonDomain;
using HexagonalRealEstate.Domain.ProspectDomain;
using System;

namespace HexagonalRealEstate.Domain.ClientDomain
{
    public class ClientServiceImpl : ClientService
    {
        private readonly PersonRepository personRepository;
        private readonly AccomodationRepository accomodationRepository;
        private readonly ProspectNotificationService prospectNotificationService;

        public ClientServiceImpl(PersonRepository personRepository, AccomodationRepository accomodationRepository,
            ProspectNotificationService prospectNotificationService)
        {
            if (personRepository == null)
                throw new ArgumentNullException(nameof(personRepository));
            if (accomodationRepository == null)
                throw new ArgumentNullException(nameof(accomodationRepository));
            if (prospectNotificationService == null)
                throw new ArgumentNullException(nameof(prospectNotificationService));

            this.personRepository = personRepository;
            this.accomodationRepository = accomodationRepository;
            this.prospectNotificationService = prospectNotificationService;
        }

        public void SellAccomodation(PersonDomain.Person person, AccomodationDomain.Accomodation accomodation)
        {
            this.CheckThatParametersAreNotNull(person, accomodation);

            this.ThrowExceptionIfAccomodationDoesNotExistInRepository(accomodation);
            this.ThrowExceptionIfPersonDoesNotExistInRepository(person);
            this.ThrowExceptionWhenAccomodationIsAlreadySold(accomodation);

            this.personRepository.SellAccomodation(person, accomodation);

            this.prospectNotificationService.NotifyAccomodationIsNoMoreAvailable(accomodation);
        }

        private void ThrowExceptionWhenAccomodationIsAlreadySold(AccomodationDomain.Accomodation accomodation)
        {
            var accomodationAlreadySold = this.personRepository.IsAccomodationSold(accomodation);
            if (accomodationAlreadySold)
                throw new AccomodationAlreadySold();
        }

        private void CheckThatParametersAreNotNull(PersonDomain.Person person, AccomodationDomain.Accomodation accomodation)
        {
            if (person == null)
                throw new ArgumentNullException(nameof(person));
            if (accomodation == null)
                throw new ArgumentNullException(nameof(accomodation));
        }

        private void ThrowExceptionIfAccomodationDoesNotExistInRepository(AccomodationDomain.Accomodation accomodation)
        {
            var accomodationExist = this.accomodationRepository.Exist(accomodation);
            if (!accomodationExist)
                throw new ObjectDoesNotExistInRepositoryException(nameof(accomodation));
        }

        private void ThrowExceptionIfPersonDoesNotExistInRepository(PersonDomain.Person person)
        {
            var personExist = this.personRepository.Exist(person);
            if (!personExist)
                throw new ObjectDoesNotExistInRepositoryException(nameof(person));
        }
    }
}
