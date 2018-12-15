using HexagonalRealEstate.Domain.AccomodationDomain.Objects;
using HexagonalRealEstate.Domain.PersonDomain.Objects;
using HexagonalRealEstate.ViewsModels;

namespace HexagonalRealEstate.Mapping
{
    public static class BusinessToModelMapping
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
