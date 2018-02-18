using HexagonalRealEstate.Domain.PersonDomain.Objects;
using HexagonalRealEstate.Infrastructure.View.Models;

namespace HexagonalRealEstate.Infrastructure.View.Helpers
{
    public static class BusinesstoModelConverter
    {
        public static PersonId ToBusinessId(this PersonModel person)
        {
            return new PersonId(
                surrogateId: person.Id
            );
        }
    }
}
