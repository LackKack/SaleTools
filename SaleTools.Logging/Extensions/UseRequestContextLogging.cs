using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace SaleTools.Logging.Extensions;

public static class PipelineExtension
{
   
    public static IHostApplicationBuilder BuildSeriLog(this WebApplicationBuilder hostApplicationBuilder, Action<HostBuilderContext, LoggerConfiguration>? configAction = null, bool preserveStaticLogger = false, bool writeToProviders = false)
    {

        if (configAction != null)
            hostApplicationBuilder.Host.UseSerilog(configAction
          , preserveStaticLogger, writeToProviders);

        else
            hostApplicationBuilder.Host.UseSerilog((context, loggerConfig)
                => loggerConfig.ReadFrom.Configuration(context.Configuration));

        return hostApplicationBuilder;
    }

    public static IApplicationBuilder UseSerilogTrackRequestLogging(this IApplicationBuilder applicationBuilder)
    {
        applicationBuilder.UseSerilogRequestLogging();
        // custom middleware
        applicationBuilder.UseMiddleware<RequestContextLoggingMiddleware>();
        return applicationBuilder;
    }
}