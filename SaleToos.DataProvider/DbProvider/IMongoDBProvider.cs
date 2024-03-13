using MongoDB.Driver;
using SaleTools.Abstracts.DataProvider;
using SaleTools.Abstracts.DbSettings;

namespace SaleTools.Abstracts.Interfaces;

public interface IMongoDBProvider<T> : IDbProvider<T>
{
    public IMongoCollection<T> GetCollections(DbSetting setting);
}