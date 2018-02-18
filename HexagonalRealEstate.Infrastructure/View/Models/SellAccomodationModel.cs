using CSharpFunctionalExtensions;

namespace HexagonalRealEstate.Infrastructure.View.Models
{
    public class SellAccomodationModel : ActionModel
    {
        public string PersonId { get; set; }
        public string AccomodationNumber { get; set; }

        public Result Evaluate()
        {
            Result idResult;
            if (string.IsNullOrWhiteSpace(this.PersonId))
                idResult = Result.Fail("The person id is mandatory");
            else
                idResult = Result.Ok(this.PersonId);

            var numberResult = Domain.AccomodationDomain.Objects.Properties.AccomodationNumber.Create(this.AccomodationNumber);
            return Result.Combine(numberResult, idResult);
        }
    }
}
