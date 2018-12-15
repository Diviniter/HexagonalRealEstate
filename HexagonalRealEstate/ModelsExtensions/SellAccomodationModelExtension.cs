using CSharpFunctionalExtensions;
using HexagonalRealEstate.Domain.AccomodationDomain.Objects.Properties;
using HexagonalRealEstate.ViewsModels;

namespace HexagonalRealEstate.ModelsExtensions
{
    public static class SellAccomodationModelExtension
    {
        public static Result Evaluate(this SellAccomodationModel model)
        {
            var idResult = GetIdResult(model);
            var numberResult = AccomodationNumber.Create(model.AccomodationNumber);

            return Result.Combine(numberResult, idResult);
        }

        private static Result GetIdResult(SellAccomodationModel model)
        {
            Result idResult;
            if (string.IsNullOrWhiteSpace(model.PersonId))
                idResult = Result.Fail("The person id is mandatory");
            else
                idResult = Result.Ok(model.PersonId);
            return idResult;
        }
    }
}
