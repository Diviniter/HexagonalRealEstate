using HexagonalRealEstate.Domain.AccomodationDomain;
using HexagonalRealEstate.Domain.PersonDomain;
using HexagonalRealEstate.Infrastructure.View.Models;

namespace HexagonalRealEstate.Infrastructure.View.Helpers
{
    public static class ModelConverter
    {
        public static Accomodation ToBusiness(this AccomodationModel accomodationModel)
        {
            return new Accomodation(accomodationModel.Number);
        }

        public static Person ToBusiness(this PersonModel personModel)
        {
            return new Person(personModel.FirstName, personModel.Name, personModel.Email);
        }

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
