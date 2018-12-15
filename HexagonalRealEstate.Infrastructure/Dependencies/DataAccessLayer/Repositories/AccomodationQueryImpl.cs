using HexagonalRealEstate.Domain.AccomodationDomain.Objects;
using HexagonalRealEstate.Helpers;
using HexagonalRealEstate.Infrastructure.Dependencies.Entities;
using HexagonalRealEstate.ViewsModels;
using System.Collections.Generic;
using System.Linq;

namespace HexagonalRealEstate.Infrastructure.Dependencies.DataAccessLayer.Repositories
{
    public class AccomodationQueryImpl : AccomodationQueryExtended
    {
        public IEnumerable<Accomodation> GetAll()
        {
            return Database.Accomodations.Select(a => a.ToBusiness());
        }

        public Accomodation Get(AccomodationId accomodation)
        {
            var accomodationEntity = Database.Accomodations.First(p => p.Number == accomodation.Number);
            return accomodationEntity.ToBusiness();
        }

        public bool Exist(AccomodationId accomodation)
        {
            return Database.Accomodations.Any(a => a.Number == accomodation.Number);
        }

        public IEnumerable<AccomodationModel> GetAvailableAccomodations()
        {
            var buyedAccomodations = Database.Clients.Select(a => a.Accomodation);
            var accomodationsEntities = Database.Accomodations.Except(buyedAccomodations);
            return accomodationsEntities.Select(a => a.ToModel());
        }
    }
}
