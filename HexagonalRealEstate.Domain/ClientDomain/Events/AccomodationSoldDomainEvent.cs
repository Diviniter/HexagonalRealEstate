using HexagonalRealEstate.Domain.AccomodationDomain.Objects;
using MediatR;

namespace HexagonalRealEstate.Domain.ClientDomain.Events
{
    public class AccomodationSoldDomainEvent : INotification
    {
        public AccomodationId Accomodation { get; private set; }

        public AccomodationSoldDomainEvent(AccomodationId accomodation)
        {
            this.Accomodation = accomodation;
        }
    }
}
