using CSharpFunctionalExtensions;
using HexagonalRealEstate.Domain.General;

namespace HexagonalRealEstate.Domain.PersonDomain.Objects.Properties
{
    public class PersonName : StringValidator<PersonName>
    {
        private PersonName(string lastName) : base(lastName)
        { }

        public static Result<PersonName> Create(string lastName)
        {
            if (string.IsNullOrWhiteSpace(lastName))
                return Result.Fail<PersonName>("Name  can't be empty");

            return Result.Ok(new PersonName(lastName));
        }

        public static implicit operator string(PersonName lastName)
        {
            return lastName._value;
        }
    }
}
