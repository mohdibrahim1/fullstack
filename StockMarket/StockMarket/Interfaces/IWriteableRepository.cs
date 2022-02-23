namespace StockMarket.Interfaces
{
    public interface IWriteableRepository<T>
    {
        long Add (T item);
        bool Update(T item);
        bool Delete (int id);
    }
}
