using CSharpFunctionalExtensions;
using HexagonalRealEstate.Domain.AccomodationDomain.Objects;
using HexagonalRealEstate.Domain.AccomodationDomain.Objects.Properties;
using HexagonalRealEstate.ViewsModels;

namespace HexagonalRealEstate.ModelsExtensions
{
    public static class CreateAccomodationModelExtension
    {
        public static Result Evaluate(this CreateAccomodationModel model)
        {
            return AccomodationNumber.Create(model.Number);
        }

        public static Accomodation ToBusinessObject(this CreateAccomodationModel model)
        {
            return new Accomodation(
                AccomodationNumber.Create(model.Number).Value
            );
        }
    }
}
