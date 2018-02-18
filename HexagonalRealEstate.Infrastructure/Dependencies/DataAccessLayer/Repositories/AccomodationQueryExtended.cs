using System.Collections.Generic;
using HexagonalRealEstate.Domain.AccomodationDomain.Objects;
using HexagonalRealEstate.Domain.AccomodationDomain.Repositories;
using HexagonalRealEstate.Infrastructure.View.Models;

namespace HexagonalRealEstate.Infrastructure.Dependencies.DataAccessLayer.Repositories
{
    public interface AccomodationQueryExtended : AccomodationQuery
    {
        Accomodation Get(AccomodationId id);
        IEnumerable<Accomodation> GetAll();
        IEnumerable<AccomodationModel> GetAvailableAccomodations();
    }
}
