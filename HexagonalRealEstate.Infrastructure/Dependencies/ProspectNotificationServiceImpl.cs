using HexagonalRealEstate.Domain.AccomodationDomain;
using HexagonalRealEstate.Domain.PersonDomain;
using HexagonalRealEstate.Domain.ProspectDomain;
using HexagonalRealEstate.Infrastructure.View;
using HexagonalRealEstate.Infrastructure.View.Helpers;
using System.Linq;

namespace HexagonalRealEstate.Infrastructure.Dependencies
{
    public class ProspectNotificationServiceImpl : ProspectNotificationService
    {
        private readonly PersonRepository personRepository;
        private readonly WriteStrategy writeStrategy;

        public ProspectNotificationServiceImpl(PersonRepository personRepository, WriteStrategy writeStrategy)
        {
            this.personRepository = personRepository;
            this.writeStrategy = writeStrategy;
        }

        public void NotifyAccomodationIsNoMoreAvailable(Accomodation accomodation)
        {
            var prospects = this.personRepository.GetProspects(accomodation);
            if (!prospects.Any())
                return;

            var prospectModel = prospects.Select(p => p.ToModel());

            var prospectsString = string.Join(",", prospectModel);
            this.writeStrategy.Write($"Inform prospects : {prospectsString}");
        }
    }
}
