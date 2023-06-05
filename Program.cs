using ApiTonic.Gateway.Extensions;
using ApiTonic.Gateway.Models;
using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);

var apiTonicSettings = builder.Configuration.GetSection("ApiTonic").Get<ApiTonicSettings>();

builder.Services
    .AddCors()
    .AddApiTonicServices(apiTonicSettings.Projects)
    .AddSingleton(ConnectionMultiplexer.Connect(apiTonicSettings.RedisAddress))
    .AddGraphQLServer()
    .AddRemoteSchemasFromRedis(apiTonicSettings.GatewayName, sp => sp.GetRequiredService<ConnectionMultiplexer>());

var app = builder.Build();

app.MapGraphQL();

app.UseCors(x => x
    .AllowAnyMethod()
    .AllowAnyHeader()
    .AllowCredentials()
    .SetIsOriginAllowed(origin => true)
);

app.Run();
