using System;
using HexagonalRealEstate.Domain.AccomodationDomain.Exceptions;
using HexagonalRealEstate.Domain.AccomodationDomain.Objects;
using HexagonalRealEstate.Domain.AccomodationDomain.Repositories;
using HexagonalRealEstate.Domain.PersonDomain.Exceptions;
using HexagonalRealEstate.Domain.PersonDomain.Objects;
using HexagonalRealEstate.Domain.PersonDomain.Repositories;
using HexagonalRealEstate.Domain.ProspectDomain.Services;

namespace HexagonalRealEstate.Domain.ClientDomain.Services
{
    public class ClientServiceImpl : ClientService
    {
        private readonly PersonQuery personQuery;
        private readonly AccomodationQuery accomodationQuery;
        private readonly PersonRepository personRepository;
        private readonly AccomodationRepository accomodationRepository;
        private readonly ProspectNotificationService prospectNotificationService;

        public ClientServiceImpl(PersonRepository personRepository, AccomodationRepository accomodationRepository,
            ProspectNotificationService prospectNotificationService, PersonQuery personQuery,
            AccomodationQuery accomodationQuery)
        {
            if (personRepository == null)
                throw new ArgumentNullException(nameof(personRepository));
            if (accomodationRepository == null)
                throw new ArgumentNullException(nameof(accomodationRepository));
            if (prospectNotificationService == null)
                throw new ArgumentNullException(nameof(prospectNotificationService));
            if (personQuery == null)
                throw new ArgumentNullException(nameof(personQuery));
            if (accomodationQuery == null)
                throw new ArgumentNullException(nameof(accomodationQuery));

            this.personRepository = personRepository;
            this.accomodationRepository = accomodationRepository;
            this.prospectNotificationService = prospectNotificationService;
            this.personQuery = personQuery;
            this.accomodationQuery = accomodationQuery;
        }

        public void SellAccomodation(PersonId person, AccomodationId accomodation)
        {
            this.CheckThatParametersAreNotNull(person, accomodation);

            this.ThrowExceptionIfAccomodationDoesNotExistInRepository(accomodation);
            this.ThrowExceptionIfPersonDoesNotExistInRepository(person);
            this.ThrowExceptionWhenAccomodationIsAlreadySold(accomodation);

            this.personRepository.SellAccomodation(person, accomodation);

            this.prospectNotificationService.NotifyAccomodationIsNoMoreAvailable(accomodation);
        }

        private void ThrowExceptionWhenAccomodationIsAlreadySold(AccomodationId accomodation)
        {
            var accomodationAlreadySold = this.personQuery.IsAccomodationSold(accomodation);
            if (accomodationAlreadySold)
                throw new AccomodationAlreadySoldException();
        }

        private void CheckThatParametersAreNotNull(PersonId person, AccomodationId accomodation)
        {
            if (person == null)
                throw new ArgumentNullException(nameof(person));
            if (accomodation == null)
                throw new ArgumentNullException(nameof(accomodation));
        }

        private void ThrowExceptionIfAccomodationDoesNotExistInRepository(AccomodationId accomodation)
        {
            var accomodationExist = this.accomodationQuery.Exist(accomodation);
            if (!accomodationExist)
                throw new AccomodationDoesNotExistException();
        }

        private void ThrowExceptionIfPersonDoesNotExistInRepository(PersonId person)
        {
            var personExist = this.personQuery.Exist(person);
            if (!personExist)
                throw new PersonDoesNotExistException();
        }
    }
}
