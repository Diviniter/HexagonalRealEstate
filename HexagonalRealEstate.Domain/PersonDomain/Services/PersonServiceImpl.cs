using System;
using HexagonalRealEstate.Domain.PersonDomain.Objects;
using HexagonalRealEstate.Domain.PersonDomain.Repositories;

namespace HexagonalRealEstate.Domain.PersonDomain.Services
{
    public class PersonServiceImpl : PersonService
    {
        private readonly PersonRepository personRepository;

        public PersonServiceImpl(PersonRepository personRepository)
        {
            if (personRepository == null)
                throw new ArgumentNullException(nameof(personRepository));
            this.personRepository = personRepository;
        }

        public void CreatePerson(Person person)
        {
            this.personRepository.Create(person);
        }
    }
}
