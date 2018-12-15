using HexagonalRealEstate.Domain.AccomodationDomain.Objects;
using HexagonalRealEstate.Domain.PersonDomain.Objects;
using HexagonalRealEstate.Infrastructure.Dependencies.DataAccessLayer.Entities;
using Optional.Unsafe;
using System;

namespace HexagonalRealEstate.Infrastructure.Converters
{
    public static class BusinessToEntitiesMapping
    {
        public static PersonEntity ToEntity(this Person person)
        {
            return new PersonEntity
            {
                Id = Guid.NewGuid().ToString(),
                FirstName = person.FirstName,
                Name = person.Name,
                Email = person.Email.ValueOrDefault()
            };
        }

        public static AccomodationEntity ToEntity(this Accomodation accomodation)
        {
            return new AccomodationEntity
            {
                Number = accomodation.Number
            };
        }
    }
}
