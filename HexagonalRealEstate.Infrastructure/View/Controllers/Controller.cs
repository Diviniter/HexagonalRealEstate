using System.Collections.Generic;
using HexagonalRealEstate.Infrastructure.View.Models;

namespace HexagonalRealEstate.Infrastructure.View.Controllers
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
