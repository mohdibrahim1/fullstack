using System.Collections.Generic;

namespace StockMarket.Interfaces
{
    public interface IReadableRepository<T>

    {
        List<T> Get();
        T GetById(int id);
    }
}
