using HexagonalRealEstate.Domain.AccomodationDomain.Objects.Properties;

namespace HexagonalRealEstate.Domain.AccomodationDomain.Objects
{
    public class AccomodationId
    {
        public AccomodationId(AccomodationNumber number)
        {
            this.Number = number;
        }

        public readonly AccomodationNumber Number;

        public override int GetHashCode()
        {
            return this.Number.ToString().GetHashCode();
        }

        public override bool Equals(object obj)
        {
            var accomodation = (Accomodation)obj;
            return accomodation.Number.Equals(this.Number);
        }
    }
}
