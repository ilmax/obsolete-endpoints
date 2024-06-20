var builder = DistributedApplication.CreateBuilder(args);

var apiService = builder.AddProject<Projects.obsolete_endpoints_ApiService>("apiservice");

builder.AddProject<Projects.obsolete_endpoints_Web>("webfrontend")
    .WithReference(apiService);

builder.Build().Run();
