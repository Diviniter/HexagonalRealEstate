using System;

namespace HexagonalRealEstate.Domain.PersonDomain
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

        public void CreatePerson(PersonDomain.Person person)
        {
            var exist = this.personRepository.Exist(person);
            if (exist)
                throw new PersonArleadyExistException();

            this.personRepository.Create(person);
        }
    }
}
