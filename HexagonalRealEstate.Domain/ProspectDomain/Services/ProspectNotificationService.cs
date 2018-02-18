using HexagonalRealEstate.Domain.AccomodationDomain.Objects;

namespace HexagonalRealEstate.Domain.ProspectDomain.Services
{
    public interface ProspectNotificationService
    {
        void NotifyAccomodationIsNoMoreAvailable(AccomodationId accomodation);
    }
}
