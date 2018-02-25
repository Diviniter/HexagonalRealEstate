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
            this.Accomodation = accomodation;
            this.Person = person;
        }
    }
}