var builder = DistributedApplication.CreateBuilder(args);

var api = builder.AddProject<Projects.AIRoutine_FullStack_Api>("api");

builder.Build().Run();
