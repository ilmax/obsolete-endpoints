using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Diagnostics;

namespace ObsoleteEndpoints.ApiService.Filters;

public class ObsoleteActionFilter : IAsyncActionFilter
{
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        var obsoleteAttribute = context.ActionDescriptor.EndpointMetadata.OfType<ObsoleteAttribute>().FirstOrDefault();
        if (obsoleteAttribute is not null)
        {
            var activity = context.HttpContext.Features.Get<IHttpActivityFeature>()?.Activity;
            activity.EnrichWithActionContext(context);
            DiagnosticConfig.ObsoleteEndpointCounter.Add(1, new KeyValuePair<string, object?>(DiagnosticNames.DisplayName, context.ActionDescriptor.DisplayName));
            await next();
        }
        else
        {
            await next();    
        }
    }
}