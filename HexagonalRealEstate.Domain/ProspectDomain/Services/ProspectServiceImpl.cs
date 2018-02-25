using HexagonalRealEstate.Domain.AccomodationDomain.Exceptions;
using HexagonalRealEstate.Domain.AccomodationDomain.Objects;
using HexagonalRealEstate.Domain.AccomodationDomain.Repositories;
using HexagonalRealEstate.Domain.PersonDomain.Exceptions;
using HexagonalRealEstate.Domain.PersonDomain.Objects;
using HexagonalRealEstate.Domain.PersonDomain.Repositories;
using HexagonalRealEstate.Domain.ProspectDomain.Exceptions;

namespace HexagonalRealEstate.Domain.ProspectDomain.Services
{
    public class ProspectServiceImpl : ProspectService
    {
        private readonly PersonRepository personRepository;
        private readonly PersonQuery personQuery;
        private readonly AccomodationQuery accomodationQuery;

        public ProspectServiceImpl(PersonRepository personRepository,
            PersonQuery personQuery,
            AccomodationQuery accomodationQuery)
        {
            this.personRepository = personRepository;
            this.personQuery = personQuery;
            this.accomodationQuery = accomodationQuery;
        }

        public void CreateProspect(PersonId person, AccomodationId accomodation)
        {
            this.ThrowExceptionIfAccomodationDoesNotExistInRepository(accomodation);
            this.ThrowExceptionIfPersonDoesNotExistInRepository(person);
            this.ThrowExceptionWhenProscpectIsAlreadyLinkedToAccomodation(person, accomodation);

            this.personRepository.CreateProspect(person, accomodation);
        }

        private void ThrowExceptionWhenProscpectIsAlreadyLinkedToAccomodation(PersonId person, AccomodationId accomodation)
        {
            var isAlreadyProspectOnThisAccomodation = this.personQuery.IsProspectOnThisAccomodation(person, accomodation);
            if (isAlreadyProspectOnThisAccomodation)
                throw new AlreadyProspectOnAccomodationException();
        }

        private void ThrowExceptionIfPersonDoesNotExistInRepository(PersonId person)
        {
            var personExist = this.personQuery.Exist(person);
            if (!personExist)
                throw new PersonDoesNotExistException();
        }

        private void ThrowExceptionIfAccomodationDoesNotExistInRepository(AccomodationId accomodation)
        {
            var accomodationExist = this.accomodationQuery.Exist(accomodation);
            if (!accomodationExist)
                throw new AccomodationDoesNotExistException();
        }
    }
}
