using HexagonalRealEstate.Domain.AccomodationDomain.Objects;
using HexagonalRealEstate.Domain.PersonDomain.Objects;

namespace HexagonalRealEstate.Domain.PersonDomain.Repositories
{
    public interface PersonRepository
    {
        void CreateProspect(PersonId person, AccomodationId accomodation);
        void SellAccomodation(PersonId person, AccomodationId accomodation);
        void Create(Person person);
    }
}
