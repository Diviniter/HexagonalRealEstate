using CSharpFunctionalExtensions;
using HexagonalRealEstate.Domain.AccomodationDomain.Objects;
using HexagonalRealEstate.Domain.AccomodationDomain.Objects.Properties;

namespace HexagonalRealEstate.Infrastructure.View.Models
{
    public class CreateAccomodationModel
    {
        public string Number { get; set; }

        public Result Evaluate()
        {
            return AccomodationNumber.Create(this.Number);
        }

        public Accomodation ToBusinessObject()
        {
            return new Accomodation(
                AccomodationNumber.Create(this.Number).Value
            );
        }
    }
}
