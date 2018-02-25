using CSharpFunctionalExtensions;
using HexagonalRealEstate.Domain.PersonDomain.Objects.Properties;

namespace HexagonalRealEstate.Domain.PersonDomain.Objects
{
    public class Person : PersonId
    {
        public Person(Maybe<string> surrogateId, PersonFirstName firstName, PersonName name, Maybe<PersonEmail> email) : base(surrogateId)
        {
            this.FirstName = firstName;
            this.Name = name;
            this.Email = email;
        }

        public PersonName Name { get; private set; }
        public PersonFirstName FirstName { get; private set; }
        public Maybe<PersonEmail> Email { get; private set; }
    }
}
