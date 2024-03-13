using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SaleTools.Abstract.Repository;
using SaleTools.Abstracts.DbSettings;
using SaleToos.DataProvider.Repository;

namespace SaleToos.DataProvider
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDataProvider(this IServiceCollection services, IConfiguration configuration, string connectionSection)
        {
            services.AddSingleton<DbSetting>(sp
                => (DbSetting)configuration.GetSection(connectionSection));
            services.AddSingleton(typeof(IMongoRepository<>), typeof(MongoRepository<>));
            return services;
        }

    }
}
