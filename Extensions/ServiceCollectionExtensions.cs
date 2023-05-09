using ApiTonic.Gateway.Models;

namespace ApiTonic.Gateway.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApiTonicServices(this IServiceCollection services,
            IEnumerable<ApiTonicProjectSettings> apiTonicProjects)
        {
            foreach (var apiTonicProject in apiTonicProjects)
            {
                services.AddHttpClient(apiTonicProject.Name, c => c.BaseAddress = new Uri(apiTonicProject.BaseAddress));
            }

            return services;
        }
    }
}
