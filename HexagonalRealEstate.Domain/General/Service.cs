using System.Collections.Generic;
using MediatR;

namespace HexagonalRealEstate.Domain.General
{
    public abstract class Service
    {
        private List<INotification> domainEvents;
        public List<INotification> DomainEvents => this.domainEvents;

        public void AddDomainEvent(INotification eventItem)
        {
            this.domainEvents = this.domainEvents ?? new List<INotification>();
            this.domainEvents.Add(eventItem);
        }

        public void RemoveDomainEvent(INotification eventItem)
        {
            this.domainEvents?.Remove(eventItem);
        }
    }
}
