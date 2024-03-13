using MongoDB.Driver;
using SaleTools.Abstract.Repository;
using SaleTools.Abstracts.DbSettings;
using SaleTools.Abstracts.Entities.MongoDb;

namespace SaleToos.DataProvider.Repository
{
    public class MongoRepository<T>:IMongoRepository<T> where T : IBaseMongoEntity<string>
    {
        private readonly IMongoCollection<T> collections;
        public MongoRepository(DbSetting setting)
        {
            var mongoClient = new MongoClient(setting.ConnectionString);
            var mongoDb = mongoClient.GetDatabase(setting.DbName);
            collections = mongoDb.GetCollection<T>(nameof(T));
        }

        public IMongoCollection<T> GetCollections(DbSetting setting) => collections;
        public async Task CreateAsync(T newRecord)
            => await collections.InsertOneAsync(newRecord);

        public async Task<List<T>> GetAsync()
            => await collections.Find(_ => true).ToListAsync();

        public async Task<T?> GetAsync(string id)
        => await collections.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task RemoveAsync(string id)
        => await collections.DeleteOneAsync(x => x.Id == id);

        public async Task UpdateAsync(string id, T record)
            => await collections.ReplaceOneAsync(x => x.Id == id, record);
    }
}
