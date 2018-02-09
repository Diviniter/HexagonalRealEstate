using System;
using System.Text.RegularExpressions;

namespace HexagonalRealEstate.Infrastructure.View.Helpers
{
    public static class ArgumentNullExceptionExtension
    {
        public static string GetParameter(this ArgumentNullException exception)
        {
            var regex = new Regex("La valeur ne peut pas être null.\r\nNom du paramètre : (.*)");
            var match = regex.Match(exception.Message);
            var parameter = match.Groups[1].Value;
            return parameter;
        }
    }
}
