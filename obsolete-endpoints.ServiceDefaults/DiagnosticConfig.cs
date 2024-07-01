using System.Diagnostics.Metrics;

namespace Microsoft.Extensions.Diagnostics;

public static class DiagnosticConfig
{
    private const string ServiceName = "ObsoleteEndpointsService";
    public static readonly Meter Meter = new(ServiceName);
    public static readonly Counter<long> ObsoleteEndpointCounter = Meter.CreateCounter<long>("ObsoleteInvocationCount");
}

public static class DiagnosticNames
{
    public const string Url = nameof(Url);
    public const string DisplayName = nameof(DisplayName);
    public const string ObsoleteEndpoint = nameof(ObsoleteEndpoint);
}
