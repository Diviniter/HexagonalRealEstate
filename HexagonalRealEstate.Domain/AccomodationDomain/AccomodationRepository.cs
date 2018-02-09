using HexagonalRealEstate.Domain.General;
using System.Collections.Generic;

namespace HexagonalRealEstate.Domain.Accomodation
{
    public interface AccomodationRepository : Repository<AccomodationDomain.Accomodation>
    {
        IEnumerable<AccomodationDomain.Accomodation> GetAvailableAccomodations();
    }
}
