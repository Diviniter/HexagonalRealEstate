using HexagonalRealEstate.Domain.Accomodation;
using HexagonalRealEstate.Domain.General;
using HexagonalRealEstate.Domain.PersonDomain;
using System;

namespace HexagonalRealEstate.Domain.ProspectDomain
{
    public class ProspectServiceImpl : ProspectService
    {
        public readonly PersonRepository personRepository;
        public readonly AccomodationRepository accomodationRepository;

        public ProspectServiceImpl(PersonRepository personRepository, AccomodationRepository accomodationRepository)
        {
            if (personRepository == null)
                throw new ArgumentNullException(nameof(personRepository));
            if (accomodationRepository == null)
                throw new ArgumentNullException(nameof(accomodationRepository));

            this.personRepository = personRepository;
            this.accomodationRepository = accomodationRepository;
        }

        public void SetPersonAsProspect(PersonDomain.Person person, AccomodationDomain.Accomodation accomodation)
        {
            this.CheckThatParametersAreNotNull(person, accomodation);

            this.ThrowExceptionIfAccomodationDoesNotExistInRepository(accomodation);
            this.ThrowExceptionIfPersonDoesNotExistInRepository(person);
            this.ThrowExceptionWhenProscpectIsAlreadyLinkedToAccomodation(person, accomodation);

            this.personRepository.SetPersonAsProspect(person, accomodation);
        }

        private void ThrowExceptionWhenProscpectIsAlreadyLinkedToAccomodation(PersonDomain.Person person, AccomodationDomain.Accomodation accomodation)
        {
            var isAlreadyProspectOnThisAccomodation = this.personRepository.IsProspectOnThisAccomodation(person, accomodation);
            if (isAlreadyProspectOnThisAccomodation)
                throw new AlreadyProspectOnAccomodationException();
        }

        private void ThrowExceptionIfPersonDoesNotExistInRepository(PersonDomain.Person person)
        {
            var personExist = this.personRepository.Exist(person);
            if (!personExist)
                throw new ObjectDoesNotExistInRepositoryException(nameof(person));
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
    }
}
