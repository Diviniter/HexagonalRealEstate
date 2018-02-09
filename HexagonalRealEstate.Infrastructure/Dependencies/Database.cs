using HexagonalRealEstate.Domain.AccomodationDomain;
using HexagonalRealEstate.Domain.PersonDomain;
using System;
using System.Collections.Generic;

namespace HexagonalRealEstate.Infrastructure.Dependencies
{
    public static class Database
    {
        public static readonly List<Person> Persons;
        public static readonly List<Accomodation> Accomodations;
        public static readonly List<Tuple<Accomodation, Person>> Clients;
        public static readonly List<Tuple<Accomodation, Person>> Prospects;

        static Database()
        {
            Persons = new List<Person>();
            Accomodations = new List<Accomodation>();
            Clients = new List<Tuple<Accomodation, Person>>();
            Prospects = new List<Tuple<Accomodation, Person>>();
        }
    }
}
