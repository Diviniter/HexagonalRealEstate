using HexagonalRealEstate.Domain.AccomodationDomain;
using HexagonalRealEstate.Domain.PersonDomain;
using HexagonalRealEstate.Domain.ProspectDomain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HexagonalRealEstate.Infrastructure.Dependencies
{
    public class PersonRepositoryImpl : PersonRepository
    {
        public IEnumerable<Person> GetAll()
        {
            return Database.Persons;
        }

        public void Create(Person person)
        {
            Database.Persons.Add(person);
        }

        public bool Exist(Person person)
        {
            return Database.Persons.Any(a => a.Equals(person));
        }

        public void SetPersonAsProspect(Person person, Accomodation accomodation)
        {
            var prospect = new Tuple<Accomodation, Person>(accomodation, person);
            Database.Prospects.Add(prospect);
        }

        public void SellAccomodation(Person person, Accomodation accomodation)
        {
            var client = new Tuple<Accomodation, Person>(accomodation, person);
            Database.Clients.Add(client);
        }

        public bool IsProspectOnThisAccomodation(Person person, Accomodation accomodation)
        {
            return Database.Prospects.Any(p => p.Item1.Equals(accomodation) && p.Item2.Equals(person));
        }

        public bool IsAccomodationSold(Accomodation accomodation)
        {
            return Database.Clients.Any(p => p.Item1.Equals(accomodation));
        }

        public IEnumerable<Prospect> GetProspects(Accomodation accomodation)
        {
            return Database.Prospects.Where(p => p.Item1.Equals(accomodation))
                .Select(p => new Prospect(p.Item2.FirstName, p.Item2.Name, p.Item2.Email, p.Item1))
                .ToList();
        }
    }
}
