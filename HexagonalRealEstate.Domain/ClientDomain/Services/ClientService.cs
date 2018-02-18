using HexagonalRealEstate.Domain.AccomodationDomain.Objects;
using HexagonalRealEstate.Domain.PersonDomain.Objects;

namespace HexagonalRealEstate.Domain.ClientDomain.Services
{
    public interface ClientService
    {
        void SellAccomodation(PersonId person, AccomodationId accomodation);
    }
}
