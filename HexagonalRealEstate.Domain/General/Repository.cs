using System.Collections.Generic;

namespace HexagonalRealEstate.Domain.General
{
    public interface Repository<T>
    {
        IEnumerable<T> GetAll();
        void Create(T element);
        bool Exist(T element);
    }
}
