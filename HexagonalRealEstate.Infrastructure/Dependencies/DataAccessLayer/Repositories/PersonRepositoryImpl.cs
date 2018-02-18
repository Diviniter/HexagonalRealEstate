using System.Collections.Generic;
using System.Linq;
using HexagonalRealEstate.Domain.AccomodationDomain.Objects;
using HexagonalRealEstate.Domain.PersonDomain.Objects;
using HexagonalRealEstate.Domain.PersonDomain.Repositories;
using HexagonalRealEstate.Infrastructure.Converters;
using HexagonalRealEstate.Infrastructure.Dependencies.DataAccessLayer.Entities;
using HexagonalRealEstate.Infrastructure.Dependencies.Entities;

namespace HexagonalRealEstate.Infrastructure.Dependencies.DataAccessLayer.Repositories
{
    public class PersonRepositoryImpl : PersonRepository
    {
        public IEnumerable<Person> GetAll()
        {
            return Database.Persons.Select(p => p.ToBusiness());
        }

        public void Create(Person person)
        {
            Database.Persons.Add(person.ToEntity());
        }

        public void CreateProspect(PersonId person, AccomodationId accomodation)
        {
            var personEntity = Database.Persons.Single(p => p.Id == person.SurrogateId);
            var accomodationEntity = Database.Accomodations.Single(p => p.Number == accomodation.Number);
            var prospect = new ProspectEntity
            {
                Person = personEntity,
                Accomodation = accomodationEntity
            };

            Database.Prospects.Add(prospect);
        }

        public void SellAccomodation(PersonId person, AccomodationId accomodation)
        {
            var personEntity = Database.Persons.Single(p => p.Id == person.SurrogateId);
            var accomodationEntity = Database.Accomodations.Single(p => p.Number == accomodation.Number);
            var client = new ClientEntity
            {
                Person = personEntity,
                Accomodation = accomodationEntity
            };

            Database.Clients.Add(client);
        }
    }
}
