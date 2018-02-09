using HexagonalRealEstate.Domain.General;
using HexagonalRealEstate.Domain.ProspectDomain;
using System.Collections.Generic;

namespace HexagonalRealEstate.Domain.PersonDomain
{
    public interface PersonRepository : Repository<PersonDomain.Person>
    {
        void SetPersonAsProspect(PersonDomain.Person person, AccomodationDomain.Accomodation accomodation);
        void SellAccomodation(PersonDomain.Person person, AccomodationDomain.Accomodation accomodation);
        bool IsProspectOnThisAccomodation(PersonDomain.Person person, AccomodationDomain.Accomodation accomodation);
        bool IsAccomodationSold(AccomodationDomain.Accomodation accomodation);
        IEnumerable<Prospect> GetProspects(AccomodationDomain.Accomodation accomodation);
    }
}
