using CSharpFunctionalExtensions;
using HexagonalRealEstate.Domain.General;
using Optional;
using System.Text.RegularExpressions;

namespace HexagonalRealEstate.Domain.PersonDomain.Objects.Properties
{
    public class PersonEmail : StringValidator<PersonEmail>
    {
        private PersonEmail(string email) : base(email) { }

        public static Result<Option<PersonEmail>> Create(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return Result.Ok(Option.None<PersonEmail>());

            if (!Regex.IsMatch(email, @"^.+@\w+\.\w{2,3}$"))
                return Result.Fail<Option<PersonEmail>>("E - mail is invalid");

            return Result.Ok(Option.Some(new PersonEmail(email)));
        }

        public static implicit operator string(PersonEmail email)
        {
            return email._value;
        }
    }
}
