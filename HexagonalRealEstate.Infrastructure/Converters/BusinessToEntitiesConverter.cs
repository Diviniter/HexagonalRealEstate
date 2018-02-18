using System;
using HexagonalRealEstate.Domain.AccomodationDomain.Objects;
using HexagonalRealEstate.Domain.PersonDomain.Objects;
using HexagonalRealEstate.Infrastructure.Dependencies.DataAccessLayer.Entities;

namespace HexagonalRealEstate.Infrastructure.Converters
{
    public static class BusinessToEntitiesConverter
    {
        public static PersonEntity ToEntity(this Person person)
        {
            string email;
            if (person.Email.HasValue)
                email = person.Email.Value;
            else
                email = null;

            return new PersonEntity
            {
                Id = Guid.NewGuid().ToString(),
                FirstName = person.FirstName,
                Name = person.Name,
                Email = email
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
