using HexagonalRealEstate.Domain.AccomodationDomain.Objects;
using HexagonalRealEstate.Domain.PersonDomain.Objects;
using HexagonalRealEstate.Helpers;
using HexagonalRealEstate.Infrastructure.Dependencies.Entities;
using HexagonalRealEstate.ViewsModels;
using Optional.Unsafe;
using System.Collections.Generic;
using System.Linq;

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
                .Where(p => p.Person.Id == person.SurrogateId.ValueOrFailure())
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
            return Database.Persons.Any(a => a.Id == person.SurrogateId.ValueOrFailure());
        }

        public bool WithSameName(string firstName, string name)
        {
            return Database.Persons
                .Where(a => a.Name == name)
                .Any(a => a.FirstName == firstName);
        }
    }
}
