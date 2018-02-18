using System.Text.RegularExpressions;
using CSharpFunctionalExtensions;
using HexagonalRealEstate.Domain.General;

namespace HexagonalRealEstate.Domain.PersonDomain.Objects.Properties
{
    public class PersonEmail : StringValidator<PersonEmail>
    {
        private PersonEmail(string email) : base(email)
        { }

        public static Result<Maybe<PersonEmail>> Create(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return Result.Ok(Maybe<PersonEmail>.None);

            if (!Regex.IsMatch(email, @"^\w+@\w+\.\w{2,3}$"))
                return Result.Fail<Maybe<PersonEmail>>("E - mail is invalid");

            return Result.Ok(Maybe<PersonEmail>.From(new PersonEmail(email)));
        }

        public static implicit operator string(PersonEmail email)
        {
            return email._value;
        }
    }
}
