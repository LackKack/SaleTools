namespace SaleTools.Abstracts.DataProvider;

public interface IDbProvider<T>
{
    Task<List<T>> GetAsync();
    Task<T?> GetAsync(string id);
    Task CreateAsync(T newRecord);
    Task UpdateAsync(string id, T record);
    Task RemoveAsync(string id);
}