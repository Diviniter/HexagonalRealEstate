using System;
using HexagonalRealEstate.Domain.AccomodationDomain.Objects.Properties;

namespace HexagonalRealEstate.Domain.AccomodationDomain.Objects
{
    public class AccomodationId
    {
        public AccomodationId(AccomodationNumber number)
        {
            if (number == null)
                throw new ArgumentNullException(nameof(number));

            this.Number = number;
        }

        public readonly AccomodationNumber Number;

        public override int GetHashCode()
        {
            return this.Number.ToString().GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            var accomodation = (Accomodation)obj;
            return accomodation.Number.Equals(this.Number);
        }
    }
}
