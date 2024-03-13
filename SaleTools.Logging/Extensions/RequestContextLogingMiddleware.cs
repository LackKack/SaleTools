using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using Serilog.Context;

namespace SaleTools.Logging.Extensions;

public class RequestContextLoggingMiddleware
{
    private const string CorrectlationIdHeadName = "X-Correctlation-Id";
    private readonly RequestDelegate requestDelegate;

    public RequestContextLoggingMiddleware(RequestDelegate requestDelegate)
    {
        this.requestDelegate = requestDelegate;
    }

    public Task Invoke(HttpContext httpContext)
    {
        var correctLationId = GetCorrectLationId(httpContext);

        using (LogContext.PushProperty("CorrelationId", correctLationId))
        {
            return requestDelegate.Invoke(httpContext);
        }
    }

    private static string GetCorrectLationId(HttpContext httpContext)
    {
        httpContext.Request.Headers.TryGetValue(CorrectlationIdHeadName, out StringValues correctLationId);

        return correctLationId.FirstOrDefault() ?? httpContext.TraceIdentifier;
    }
}