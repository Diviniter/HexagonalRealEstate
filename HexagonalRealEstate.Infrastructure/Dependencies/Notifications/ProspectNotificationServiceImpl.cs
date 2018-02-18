using System.Linq;
using HexagonalRealEstate.Domain.AccomodationDomain.Objects;
using HexagonalRealEstate.Domain.ProspectDomain.Services;
using HexagonalRealEstate.Infrastructure.Dependencies.DataAccessLayer.Repositories;
using HexagonalRealEstate.Infrastructure.View;

namespace HexagonalRealEstate.Infrastructure.Dependencies.Notifications
{
    public class ProspectNotificationServiceImpl : ProspectNotificationService
    {
        private readonly PersonQueryExtended personQuery;
        private readonly WriteStrategy writeStrategy;

        public ProspectNotificationServiceImpl(WriteStrategy writeStrategy, PersonQueryExtended personQuery)
        {
            this.personQuery = personQuery;
            this.writeStrategy = writeStrategy;
        }

        public void NotifyAccomodationIsNoMoreAvailable(AccomodationId accomodation)
        {
            var prospects = this.personQuery.GetProspects(accomodation);
            if (!prospects.Any())
                return;

            var prospectsModel = prospects.Select(p => $"{p.FirstName} {p.Name}");

            var prospectsString = string.Join(",", prospectsModel);
            this.writeStrategy.Write($"Inform prospects : {prospectsString}");
        }
    }
}
