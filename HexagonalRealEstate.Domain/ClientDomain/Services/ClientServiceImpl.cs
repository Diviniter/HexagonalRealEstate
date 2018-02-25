using HexagonalRealEstate.Domain.AccomodationDomain.Exceptions;
using HexagonalRealEstate.Domain.AccomodationDomain.Objects;
using HexagonalRealEstate.Domain.AccomodationDomain.Repositories;
using HexagonalRealEstate.Domain.ClientDomain.Events;
using HexagonalRealEstate.Domain.PersonDomain.Exceptions;
using HexagonalRealEstate.Domain.PersonDomain.Objects;
using HexagonalRealEstate.Domain.PersonDomain.Repositories;
using MediatR;

namespace HexagonalRealEstate.Domain.ClientDomain.Services
{
    public class ClientServiceImpl : ClientService
    {
        private readonly PersonQuery personQuery;
        private readonly AccomodationQuery accomodationQuery;
        private readonly IMediator mediator;
        private readonly PersonRepository personRepository;

        public ClientServiceImpl(PersonRepository personRepository,
            PersonQuery personQuery,
            AccomodationQuery accomodationQuery,
            IMediator mediator)
        {
            this.personRepository = personRepository;
            this.personQuery = personQuery;
            this.accomodationQuery = accomodationQuery;
            this.mediator = mediator;
        }

        public void SellAccomodation(PersonId person, AccomodationId accomodation)
        {
            this.ThrowExceptionIfAccomodationDoesNotExistInRepository(accomodation);
            this.ThrowExceptionIfPersonDoesNotExistInRepository(person);
            this.ThrowExceptionWhenAccomodationIsAlreadySold(accomodation);

            this.personRepository.SellAccomodation(person, accomodation);

            this.mediator.Publish(new AccomodationSoldDomainEvent(accomodation));
        }

        private void ThrowExceptionWhenAccomodationIsAlreadySold(AccomodationId accomodation)
        {
            var accomodationAlreadySold = this.personQuery.IsAccomodationSold(accomodation);
            if (accomodationAlreadySold)
                throw new AccomodationAlreadySoldException();
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
