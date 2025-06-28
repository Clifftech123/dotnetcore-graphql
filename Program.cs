using dotnetcore_graphql.src.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Register services using the extension method
builder.Services.ConfigureServices();

var app = builder.Build();

// Configure pipeline using the extension method
ServiceExtensions.Configure(app, app.Environment);

app.Run();
