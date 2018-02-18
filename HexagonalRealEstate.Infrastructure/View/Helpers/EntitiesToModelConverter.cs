using HexagonalRealEstate.Infrastructure.Dependencies.DataAccessLayer.Entities;
using HexagonalRealEstate.Infrastructure.View.Models;

namespace HexagonalRealEstate.Infrastructure.View.Helpers
{
    public static class EntitiesToModelConverter
    {
        public static AccomodationModel ToModel(this AccomodationEntity accomodation)
        {
            return new AccomodationModel
            {
                Number = accomodation.Number
            };
        }

        public static PersonModel ToModel(this PersonEntity person)
        {
            return new PersonModel
            {
                Id = person.Id,
                FirstName = person.FirstName,
                Name = person.Name,
                Email = person.Email
            };
        }
    }
}
