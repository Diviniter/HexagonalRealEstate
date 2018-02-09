using HexagonalRealEstate.Domain.Accomodation;
using HexagonalRealEstate.Domain.AccomodationDomain;
using System.Collections.Generic;
using System.Linq;

namespace HexagonalRealEstate.Infrastructure.Dependencies
{
    public class AccomodationRepositoryImpl : AccomodationRepository
    {
        public IEnumerable<Accomodation> GetAll()
        {
            return Database.Accomodations;
        }

        public void Create(Accomodation accomodation)
        {
            Database.Accomodations.Add(accomodation);
        }

        public bool Exist(Accomodation accomodation)
        {
            return Database.Accomodations.Any(a => a.Equals(accomodation));
        }

        public IEnumerable<Accomodation> GetAvailableAccomodations()
        {
            var buyedAccomodations = Database.Clients.Select(a => a.Item1);
            return Database.Accomodations.Except(buyedAccomodations);
        }
    }
}
