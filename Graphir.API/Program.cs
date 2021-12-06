using Graphir.API;

var builder = WebApplication.CreateBuilder(args);

// Configure services on the builder (ConfigureServices)
builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>();

var app = builder.Build();

//app.MapGet("/", () => "Hello World!");

app
    .UseRouting()
    .UseEndpoints(endpoints =>
    {
        endpoints.MapGraphQL();
    });

app.Run();
