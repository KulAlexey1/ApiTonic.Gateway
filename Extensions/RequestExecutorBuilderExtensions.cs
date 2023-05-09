using ApiTonic.Gateway.Models;
using HotChocolate.Execution.Configuration;

namespace ApiTonic.Gateway.Extensions
{
    public static class RequestExecutorBuilderExtensions
    {
        public static IRequestExecutorBuilder AddApiTonicSchemas(this IRequestExecutorBuilder requestExecutorBuilder,
            IEnumerable<ApiTonicProjectSettings> apiTonicProjects)
        {
            foreach (var apiTonicProject in apiTonicProjects)
            {
                requestExecutorBuilder.AddRemoteSchema(apiTonicProject.Name);
            }

            return requestExecutorBuilder;
        }
    }
}
