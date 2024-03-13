namespace SaleTools.Abstract.Repository;

public interface IMongoRepository<T>
{
    Task<List<T>> GetAsync();
    Task<T?> GetAsync(string id);
    Task CreateAsync(T newRecord);
    Task UpdateAsync(string id, T record);
    Task RemoveAsync(string id);
}