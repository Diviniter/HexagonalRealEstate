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
            this.Accomodation = accomodation;
            this.Person = person;
        }
    }
}
