using System.Diagnostics;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Diagnostics;

namespace ObsoleteEndpoints.ApiService.Filters;

public static class ActivityExtensions
{
    public static void EnrichWithEndpoint(this Activity? activity, Endpoint endpoint, HttpContext httpContext)
    {
        activity?.SetTag(DiagnosticNames.Url, httpContext.Request.GetDisplayUrl());
        activity?.SetTag(DiagnosticNames.DisplayName, endpoint.DisplayName);
    }
    
    public static void EnrichWithActionContext(this Activity? activity, ActionExecutingContext context)
    {
        activity?.SetTag(DiagnosticNames.Url, context.HttpContext.Request.GetDisplayUrl());
        activity?.SetTag(DiagnosticNames.DisplayName, context.ActionDescriptor.DisplayName);
    }
}