using HexagonalRealEstate.ViewsModels;
using System.Collections.Generic;

namespace HexagonalRealEstate.Controllers
{
    public interface Controller
    {
        string SellAccomodation(SellAccomodationModel clientModel);
        string CreateAccomodation(CreateAccomodationModel accomodationModel);
        IEnumerable<AccomodationModel> GetAvailableAccomodations();
        IEnumerable<PersonModel> GetPersons();
        string CreatePerson(CreatePersonModel person);
        string CreateProspect(CreateProspectModel model);
    }
}
