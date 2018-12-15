using HexagonalRealEstate.Domain.AccomodationDomain.Objects;
using HexagonalRealEstate.Domain.AccomodationDomain.Objects.Properties;
using HexagonalRealEstate.Domain.PersonDomain.Objects;
using HexagonalRealEstate.Domain.PersonDomain.Objects.Properties;
using HexagonalRealEstate.Infrastructure.Dependencies.DataAccessLayer.Entities;
using Optional;

namespace HexagonalRealEstate.Infrastructure.Dependencies.Entities
{
    public static class EntitiesToBusinessMapping
    {
        public static Accomodation ToBusiness(this AccomodationEntity personEntity)
        {
            return new Accomodation(
                AccomodationNumber.Create(personEntity.Number).Value
            );
        }

        public static Person ToBusiness(this PersonEntity personEntity)
        {
            return new Person(
               surrogateId: Option.Some(personEntity.Id),
               firstName: PersonFirstName.Create(personEntity.FirstName).Value,
               name: PersonName.Create(personEntity.Name).Value,
               email: PersonEmail.Create(personEntity.Email).Value);
        }
    }
}
