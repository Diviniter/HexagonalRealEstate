using System.Collections.Generic;
using System.Linq;
using HexagonalRealEstate.Domain.AccomodationDomain.Objects;
using HexagonalRealEstate.Domain.PersonDomain.Objects;
using HexagonalRealEstate.Infrastructure.Dependencies.Entities;
using HexagonalRealEstate.Infrastructure.View.Helpers;
using HexagonalRealEstate.Infrastructure.View.Models;

namespace HexagonalRealEstate.Infrastructure.Dependencies.DataAccessLayer.Repositories
{
    public class PersonQueryImpl : PersonQueryExtended
    {
        public IEnumerable<PersonModel> GetAll()
        {
            return Database.Persons.Select(p => p.ToModel());
        }

        public bool IsProspectOnThisAccomodation(PersonId person, AccomodationId accomodation)
        {
            return Database.Prospects
                .Where(p => p.Person.Id == person.SurrogateId)
                .Any(p => p.Accomodation.Number == accomodation.Number);
        }

        public bool IsAccomodationSold(AccomodationId accomodation)
        {
            return Database.Clients.Any(c => c.Accomodation.Number == accomodation.Number);
        }

        public IEnumerable<Person> GetProspects(AccomodationId accomodation)
        {
            return Database.Prospects
                .Where(p => p.Accomodation.Number == accomodation.Number)
                .Select(p => p.Person.ToBusiness());
        }

        public bool Exist(PersonId person)
        {
            return Database.Persons.Any(a => a.Id == person.SurrogateId);
        }

        public bool WithSameName(string firstName, string name)
        {
            return Database.Persons
                .Where(a => a.Name == name)
                .Any(a => a.FirstName == firstName);
        }
    }
}
