using HexagonalRealEstate.Domain.AccomodationDomain.Objects;
using HexagonalRealEstate.Domain.PersonDomain.Objects;

namespace HexagonalRealEstate.Domain.PersonDomain.Repositories
{
    public interface PersonQuery
    {
        bool IsProspectOnThisAccomodation(PersonId person, AccomodationId accomodation);
        bool IsAccomodationSold(AccomodationId accomodation);
        bool Exist(PersonId person);
    }
}
