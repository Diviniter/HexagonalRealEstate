using HexagonalRealEstate.Domain.AccomodationDomain.Objects;
using HexagonalRealEstate.Domain.AccomodationDomain.Repositories;
using HexagonalRealEstate.Infrastructure.Converters;

namespace HexagonalRealEstate.Infrastructure.Dependencies.DataAccessLayer.Repositories
{
    public class AccomodationRepositoryImpl : AccomodationRepository
    {
        public void Create(Accomodation accomodation)
        {
            Database.Accomodations.Add(accomodation.ToEntity());
        }
    }
}
