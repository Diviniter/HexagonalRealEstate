using HexagonalRealEstate.Infrastructure.Dependencies.DataAccessLayer.Entities;
using HexagonalRealEstate.ViewsModels;

namespace HexagonalRealEstate.Helpers
{
    public static class EntitiesToModelMapping
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
