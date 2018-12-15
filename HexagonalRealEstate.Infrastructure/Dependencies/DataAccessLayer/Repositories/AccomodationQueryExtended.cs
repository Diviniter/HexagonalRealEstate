using HexagonalRealEstate.Domain.AccomodationDomain.Objects;
using HexagonalRealEstate.Domain.AccomodationDomain.Repositories;
using HexagonalRealEstate.ViewsModels;
using System.Collections.Generic;

namespace HexagonalRealEstate.Infrastructure.Dependencies.DataAccessLayer.Repositories
{
    public interface AccomodationQueryExtended : AccomodationQuery
    {
        Accomodation Get(AccomodationId id);
        IEnumerable<Accomodation> GetAll();
        IEnumerable<AccomodationModel> GetAvailableAccomodations();
    }
}
