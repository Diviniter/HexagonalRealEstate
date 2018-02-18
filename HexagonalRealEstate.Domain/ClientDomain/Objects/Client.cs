using System;
using HexagonalRealEstate.Domain.AccomodationDomain.Objects;
using HexagonalRealEstate.Domain.PersonDomain.Objects;

namespace HexagonalRealEstate.Domain.ClientDomain.Objects
{
    public class Client
    {
        public readonly Accomodation Accomodation;
        public readonly Person Person;

        public Client(Person person, Accomodation accomodation)
        {
            if (accomodation == null)
                throw new ArgumentNullException(nameof(accomodation));
            if (person == null)
                throw new ArgumentNullException(nameof(person));

            this.Accomodation = accomodation;
            this.Person = person;
        }
    }
}