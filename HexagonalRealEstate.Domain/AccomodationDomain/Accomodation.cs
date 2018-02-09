using System;

namespace HexagonalRealEstate.Domain.AccomodationDomain
{
    public class Accomodation
    {
        public string Number { get; private set; }

        public Accomodation(string number)
        {
            if (string.IsNullOrWhiteSpace(number))
                throw new ArgumentNullException(nameof(number));

            this.Number = number;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            var accomodation = (Accomodation)obj;
            return accomodation.Number == this.Number;
        }
    }
}
