using ApiTonic.Gateway.Extensions;
using ApiTonic.Gateway.Models;
using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);

var apiTonicSettings = builder.Configuration.GetSection("ApiTonic").Get<ApiTonicSettings>();

var services = builder.Services;
services
    .AddApiTonicServices(apiTonicSettings.Projects);
services
    .AddSingleton(ConnectionMultiplexer.Connect(apiTonicSettings.RedisAddress))
    .AddGraphQLServer()
    .AddRemoteSchemasFromRedis(apiTonicSettings.GatewayName, sp => sp.GetRequiredService<ConnectionMultiplexer>());

var app = builder.Build();

app.MapGraphQL();

app.Run();
