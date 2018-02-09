using System;

namespace HexagonalRealEstate.Domain.ClientDomain
{
    public class Client : PersonDomain.Person
    {
        public readonly AccomodationDomain.Accomodation Accomodation;

        public Client(string firstname, string name, string email, AccomodationDomain.Accomodation accomodation)
            : base(firstname, name, email)
        {
            if (accomodation == null)
                throw new ArgumentNullException(nameof(accomodation));

            this.Accomodation = accomodation;
        }
    }
}