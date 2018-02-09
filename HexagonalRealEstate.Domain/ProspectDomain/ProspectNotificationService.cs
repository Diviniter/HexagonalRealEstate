namespace HexagonalRealEstate.Domain.ProspectDomain
{
    public interface ProspectNotificationService
    {
        void NotifyAccomodationIsNoMoreAvailable(AccomodationDomain.Accomodation accomodation);
    }
}
