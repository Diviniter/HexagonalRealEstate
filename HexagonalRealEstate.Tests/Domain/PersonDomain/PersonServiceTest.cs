using CSharpFunctionalExtensions;
using HexagonalRealEstate.Domain.PersonDomain.Objects;
using HexagonalRealEstate.Domain.PersonDomain.Objects.Properties;
using HexagonalRealEstate.Domain.PersonDomain.Repositories;
using HexagonalRealEstate.Domain.PersonDomain.Services;
using NSubstitute;
using Xunit;

namespace HexagonalRealEstate.Tests.Domain.PersonDomain
{
    public class PersonServiceTest
    {
        private Person GetDefaultPerson()
        {
            return new Person(
                Maybe<string>.None,
                firstName: PersonFirstName.Create("firstname").Value,
                name: PersonName.Create("name").Value,
                email: PersonEmail.Create("email@email.fr").Value
                );
        }

        [Fact]
        public void CreatePersonShouldCallRepository()
        {
            var person = this.GetDefaultPerson();
            var personRepository = Substitute.For<PersonRepository>();
            var personService = new PersonServiceImpl(personRepository);

            personService.CreatePerson(person);

            personRepository.Received().Create(person);
        }
    }
}
