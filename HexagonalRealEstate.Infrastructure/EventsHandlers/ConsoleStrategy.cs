using System;

namespace HexagonalRealEstate.Infrastructure.View
{
    public class ConsoleStrategy : WriteStrategy
    {
        public void Write(string message)
        {
            Console.WriteLine(message);
        }
    }
}
