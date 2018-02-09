using HexagonalRealEstate.Infrastructure.View.Models;
using System.Collections.Generic;

namespace HexagonalRealEstate.Infrastructure.View
{
    public interface Controller
    {
        void SellAccomodation(PersonModel person, AccomodationModel accomodation);
        void CreateAccomodation(AccomodationModel accomodation);
        IEnumerable<AccomodationModel> GetAvailableAccomodations();
        IEnumerable<PersonModel> GetPersons();
        void CreatePerson(PersonModel person);
        void SetPersonAsProspect(PersonModel person, AccomodationModel accomodation);
    }
}
