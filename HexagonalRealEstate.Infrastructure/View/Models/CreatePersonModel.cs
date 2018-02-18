using CSharpFunctionalExtensions;
using HexagonalRealEstate.Domain.PersonDomain.Objects;
using HexagonalRealEstate.Domain.PersonDomain.Objects.Properties;

namespace HexagonalRealEstate.Infrastructure.View.Models
{
    public class CreatePersonModel
    {
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }

        public Result Evaluate()
        {
            var firstName = PersonFirstName.Create(this.FirstName);
            var name = PersonName.Create(this.Name);
            var email = PersonEmail.Create(this.Email);

            return Result.Combine(firstName, name, email);
        }

        public Person ToBusinessObject()
        {
            return new Person(
                surrogateId: Maybe<string>.None,
                firstName: PersonFirstName.Create(this.FirstName).Value,
                name: PersonName.Create(this.Name).Value,
                email: PersonEmail.Create(this.Email).Value);
        }
    }
}
