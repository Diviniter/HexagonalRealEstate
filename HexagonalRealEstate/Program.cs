using HexagonalRealEstate.Domain.AccomodationDomain;
using HexagonalRealEstate.Domain.PersonDomain;
using HexagonalRealEstate.Infrastructure.Dependencies;
using HexagonalRealEstate.Views;
using System;

namespace HexagonalRealEstate
{
    class Program
    {
        static void Main(string[] args)
        {
            InitializeDatabase();

            WelcomeView.SelectUserType();

            Console.Read();
        }

        private static void InitializeDatabase()
        {
            var damien = new Person("Damien", "Hanoun", "d.hanoun@bouygues-immobilier.com");
            Database.Persons.Add(damien);
            var firstAccomodation = new Accomodation("A100");
            Database.Accomodations.Add(firstAccomodation);
            Database.Prospects.Add(new Tuple<Accomodation, Person>(firstAccomodation, damien));

            var jeanSebastien = new Person("Jean Sébastien", "Coudray", "j.coudray@bouygues-immobilier.com");
            Database.Persons.Add(jeanSebastien);
            var secondAccomodation = new Accomodation("A200");
            Database.Accomodations.Add(secondAccomodation);
            Database.Clients.Add(new Tuple<Accomodation, Person>(secondAccomodation, jeanSebastien));
        }
    }
}
