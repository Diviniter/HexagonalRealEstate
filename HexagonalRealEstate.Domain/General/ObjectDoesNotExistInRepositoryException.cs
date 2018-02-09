using System;

namespace HexagonalRealEstate.Domain.General
{
    public class ObjectDoesNotExistInRepositoryException : Exception
    {
        public ObjectDoesNotExistInRepositoryException(string message) : base(message)
        {

        }
    }
}
