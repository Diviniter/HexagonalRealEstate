using HexagonalRealEstate.Domain.AccomodationDomain.Objects;
using HexagonalRealEstate.Domain.AccomodationDomain.Repositories;
using HexagonalRealEstate.Infrastructure.Converters;
using MediatR;

namespace HexagonalRealEstate.Infrastructure.Dependencies.DataAccessLayer.Repositories
{
    public class AccomodationRepositoryImpl : AccomodationRepository
    {
        private readonly IMediator mediator;

        public AccomodationRepositoryImpl(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public void Create(Accomodation accomodation)
        {
            Database.Accomodations.Add(accomodation.ToEntity());
        }
    }
}
