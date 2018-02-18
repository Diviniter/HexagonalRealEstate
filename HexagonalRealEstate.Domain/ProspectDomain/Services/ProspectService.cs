using HexagonalRealEstate.Domain.AccomodationDomain.Objects;
using HexagonalRealEstate.Domain.PersonDomain.Objects;

namespace HexagonalRealEstate.Domain.ProspectDomain.Services
{
    public interface ProspectService
    {
        void CreateProspect(PersonId person, AccomodationId accomodation);
    }
}
