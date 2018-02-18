using System.Text.RegularExpressions;
using CSharpFunctionalExtensions;
using HexagonalRealEstate.Domain.General;

namespace HexagonalRealEstate.Domain.AccomodationDomain.Objects.Properties
{
    public class AccomodationNumber : StringValidator<AccomodationNumber>
    {
        private AccomodationNumber(string number) : base(number)
        { }

        public static Result<AccomodationNumber> Create(string number)
        {
            if (string.IsNullOrWhiteSpace(number))
                return Result.Fail<AccomodationNumber>("Number can't be empty");

            var regex = new Regex(@"^[a-zA-Z]\d{3}$");
            if (!regex.IsMatch(number))
                return Result.Fail<AccomodationNumber>("Number must respect the following rule : one letter followed by three numbers");

            return Result.Ok(new AccomodationNumber(number));
        }

        public static implicit operator string(AccomodationNumber number)
        {
            return number._value;
        }
    }
}
