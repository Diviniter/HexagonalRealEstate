using HexagonalRealEstate.Domain.AccomodationDomain.Objects;

namespace HexagonalRealEstate.Domain.AccomodationDomain.Repositories

{
    public interface AccomodationQuery
    {
        bool Exist(AccomodationId accomodation);
    }
}
