using HexagonalRealEstate.Domain.ClientDomain.Events;
using HexagonalRealEstate.Infrastructure.Dependencies.DataAccessLayer.Repositories;
using HexagonalRealEstate.Infrastructure.View;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HexagonalRealEstate.Infrastructure.EventsHandlers
{
    public class NotifyProspectsWhenAccomodationIsSoldDomainEventHandler
        : INotificationHandler<AccomodationSoldDomainEvent>
    {
        private readonly PersonQueryExtended personQuery;
        private readonly WriteStrategy writeStrategy;

        public NotifyProspectsWhenAccomodationIsSoldDomainEventHandler(WriteStrategy writeStrategy, PersonQueryExtended personQuery)
        {
            this.personQuery = personQuery;
            this.writeStrategy = writeStrategy;
        }

        public Task Handle(AccomodationSoldDomainEvent notification, CancellationToken cancellationToken)
        {
            var prospects = this.personQuery.GetProspects(notification.Accomodation);
            if (!prospects.Any())
                return Task.FromResult(0);

            var prospectsModel = prospects.Select(p => $"{p.FirstName} {p.Name}");

            var prospectsString = string.Join(",", prospectsModel);
            this.writeStrategy.Write($"Inform prospects : {prospectsString}");

            return Task.FromResult(0);
        }
    }
}
