using CSharpFunctionalExtensions;
using HexagonalRealEstate.Domain.General;

namespace HexagonalRealEstate.Domain.PersonDomain.Objects.Properties
{
    public class PersonFirstName : StringValidator<PersonFirstName>
    {
        private PersonFirstName(string firstName) : base(firstName)
        { }

        public static Result<PersonFirstName> Create(string firstName)
        {
            if (string.IsNullOrWhiteSpace(firstName))
                return Result.Fail<PersonFirstName>("FirstName can't be empty");

            return Result.Ok(new PersonFirstName(firstName));
        }

        public static implicit operator string(PersonFirstName firstName)
        {
            return firstName._value;
        }
    }
}
