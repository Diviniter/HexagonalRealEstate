using CSharpFunctionalExtensions;
using HexagonalRealEstate.Domain.PersonDomain.Objects;
using HexagonalRealEstate.Domain.PersonDomain.Objects.Properties;
using HexagonalRealEstate.ViewsModels;
using Optional;

namespace HexagonalRealEstate.ModelsExtensions
{
    public static class CreatePersonModelExtension
    {
        public static Result Evaluate(this CreatePersonModel model)
        {
            var firstName = PersonFirstName.Create(model.FirstName);
            var name = PersonName.Create(model.Name);
            var email = PersonEmail.Create(model.Email);

            return Result.Combine(firstName, name, email);
        }

        public static Person ToBusinessObject(this CreatePersonModel model)
        {
            return new Person(
                surrogateId: Option.None<string>(),
                firstName: PersonFirstName.Create(model.FirstName).Value,
                name: PersonName.Create(model.Name).Value,
                email: PersonEmail.Create(model.Email).Value);
        }
    }
}
