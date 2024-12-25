var builder = DistributedApplication.CreateBuilder(args);

var apiService = builder.AddProject<Projects.dotnetBlazorFullStuck_ApiService>("apiservice");

builder.AddProject<Projects.dotnetBlazorFullStuck_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(apiService)
    .WaitFor(apiService);

builder.Build().Run();
