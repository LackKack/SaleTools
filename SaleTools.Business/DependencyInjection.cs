using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace SaleTools.Business
{
    public static class DependencyInjection
    {
        public static Task AddBusinessSection(this IServiceCollection services, IConfiguration configuration)
        {

            return Task.CompletedTask;
        }
    }
}
