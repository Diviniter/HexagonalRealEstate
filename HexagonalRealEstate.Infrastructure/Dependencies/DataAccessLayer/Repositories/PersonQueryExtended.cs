using HexagonalRealEstate.Domain.AccomodationDomain.Objects;
using HexagonalRealEstate.Domain.PersonDomain.Objects;
using HexagonalRealEstate.Domain.PersonDomain.Repositories;
using HexagonalRealEstate.ViewsModels;
using System.Collections.Generic;

namespace HexagonalRealEstate.Infrastructure.Dependencies.DataAccessLayer.Repositories
{
    public interface PersonQueryExtended : PersonQuery
    {
        IEnumerable<PersonModel> GetAll();
        IEnumerable<Person> GetProspects(AccomodationId accomodation);
        bool WithSameName(string firstName, string name);
    }
}
