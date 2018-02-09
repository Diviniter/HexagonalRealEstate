using HexagonalRealEstate.Domain.PersonDomain;
using NFluent;
using NSubstitute;
using Xunit;

namespace HexagonalRealEstate.Tests.Domain.PersonDomain
{
    public class PersonServiceTest
    {
        [Fact]
        public void CreatePersonShouldCallRepository()
        {
            var person = new HexagonalRealEstate.Domain.PersonDomain.Person("damien", "hanoun", "email@email.fr");
            var personRepository = Substitute.For<PersonRepository>();
            var personService = new PersonServiceImpl(personRepository);
            personRepository.Exist(person).Returns(false);

            personService.CreatePerson(person);

            personRepository.Received().Create(person);
        }

        [Fact]
        public void CreatePersonShouldThrowExceptionWhenPersonAlreadyExist()
        {
            var person = new HexagonalRealEstate.Domain.PersonDomain.Person("damien", "hanoun", "email@email.fr");
            var personRepository = Substitute.For<PersonRepository>();
            var personService = new PersonServiceImpl(personRepository);

            personRepository.Exist(person).Returns(true);

            Check.ThatCode(() => { personService.CreatePerson(person); })
                .Throws<PersonArleadyExistException>();
        }
    }
}
