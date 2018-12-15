using HexagonalRealEstate.Domain.PersonDomain.Objects;
using HexagonalRealEstate.ViewsModels;
using Optional;

namespace HexagonalRealEstate.Mapping
{
    public static class ModelToBusinessMapping
    {
        public static PersonId ToBusinessId(this PersonModel person)
        {
            return new PersonId(
                surrogateId: Option.Some(person.Id)
            );
        }
    }
}
