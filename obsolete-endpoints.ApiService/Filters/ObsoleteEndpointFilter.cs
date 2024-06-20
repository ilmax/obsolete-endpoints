using Microsoft.Extensions.Diagnostics;

namespace ObsoleteEndpoints.ApiService.Filters;

public class ObsoleteEndpointFilter : IEndpointFilter
{
    public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {
        var endpoint = context.HttpContext.GetEndpoint();
        if (endpoint is not null)
        {
            var obsolete = endpoint.Metadata.OfType<ObsoleteAttribute>().FirstOrDefault();
            if (obsolete is not null)
            {
                using var activity = DiagnosticConfig.Source.StartActivity(DiagnosticNames.ObsoleteEndpointInvocation);
                activity.EnrichWithEndpoint(endpoint, context.HttpContext);
                DiagnosticConfig.ObsoleteEndpointCounter.Add(1, new KeyValuePair<string, object?>(DiagnosticNames.DisplayName, endpoint.DisplayName));
                return await next(context);
            }
        }

        return await next(context);
    }
}