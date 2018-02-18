using System;
using HexagonalRealEstate.Domain.AccomodationDomain.Objects;
using HexagonalRealEstate.Domain.PersonDomain.Objects;

namespace HexagonalRealEstate.Domain.ProspectDomain.Objects
{
    public class Prospect
    {
        public readonly Accomodation Accomodation;
        public readonly Person Person;

        public Prospect(Person person, Accomodation accomodation)
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
