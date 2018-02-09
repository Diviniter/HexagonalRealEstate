using System;

namespace HexagonalRealEstate.Domain.ProspectDomain
{
    public class Prospect : PersonDomain.Person
    {
        public readonly AccomodationDomain.Accomodation InterestingAccomodation;

        public Prospect(string firstname, string name, string email, AccomodationDomain.Accomodation interestingAccomodation)
            : base(firstname, name, email)
        {
            if (interestingAccomodation == null)
                throw new ArgumentNullException(nameof(interestingAccomodation));

            this.InterestingAccomodation = interestingAccomodation;
        }
    }
}
