using HexagonalRealEstate.Domain.PersonDomain.Objects.Properties;
using Optional;

namespace HexagonalRealEstate.Domain.PersonDomain.Objects
{
    public class Person : PersonId
    {
        public Person(Option<string> surrogateId, PersonFirstName firstName, PersonName name, Option<PersonEmail> email) : base(surrogateId)
        {
            this.FirstName = firstName;
            this.Name = name;
            this.Email = email;
        }

        public PersonName Name { get; private set; }
        public PersonFirstName FirstName { get; private set; }
        public Option<PersonEmail> Email { get; private set; }
    }
}
