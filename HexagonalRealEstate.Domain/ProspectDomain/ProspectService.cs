namespace HexagonalRealEstate.Domain.ProspectDomain
{
    public interface ProspectService
    {
        void SetPersonAsProspect(PersonDomain.Person person, AccomodationDomain.Accomodation accomodation);
    }
}
