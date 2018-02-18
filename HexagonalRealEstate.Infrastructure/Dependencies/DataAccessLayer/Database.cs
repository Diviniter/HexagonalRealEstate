using System.Collections.Generic;
using HexagonalRealEstate.Infrastructure.Dependencies.DataAccessLayer.Entities;

namespace HexagonalRealEstate.Infrastructure.Dependencies.DataAccessLayer
{
    public static class Database
    {
        public static readonly List<PersonEntity> Persons;
        public static readonly List<AccomodationEntity> Accomodations;
        public static readonly List<ClientEntity> Clients;
        public static readonly List<ProspectEntity> Prospects;

        static Database()
        {
            Persons = new List<PersonEntity>();
            Accomodations = new List<AccomodationEntity>();
            Clients = new List<ClientEntity>();
            Prospects = new List<ProspectEntity>();
        }
    }
}
