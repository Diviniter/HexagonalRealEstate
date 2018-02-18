using HexagonalRealEstate.Domain.AccomodationDomain.Objects;
using HexagonalRealEstate.Domain.PersonDomain.Objects;
using HexagonalRealEstate.Infrastructure.View.Models;

namespace HexagonalRealEstate.Infrastructure.View.Helpers
{
    public static class BusinessToModelConverter
    {
        public static AccomodationModel ToModel(this Accomodation accomodation)
        {
            return new AccomodationModel
            {
                Number = accomodation.Number
            };
        }

        public static PersonModel ToModel(this Person person)
        {
            return new PersonModel
            {
                Name = person.Name,
                FirstName = person.FirstName
            };
        }
    }
}
