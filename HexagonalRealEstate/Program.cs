using System;
using HexagonalRealEstate.Views;

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
        }
    }
}
