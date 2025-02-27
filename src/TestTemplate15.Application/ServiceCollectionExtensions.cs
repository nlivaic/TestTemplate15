using Microsoft.Extensions.DependencyInjection;
using TestTemplate15.Application.Pipelines;

namespace TestTemplate15.Application
{
    public static class ServiceCollectionExtensions
    {
        public static void AddTestTemplate15ApplicationHandlers(this IServiceCollection services)
        {
            services.AddMediatR(config => config.RegisterServicesFromAssemblyContaining(typeof(ServiceCollectionExtensions)));
            services.AddPipelines();
            services.AddAutoMapper(typeof(ServiceCollectionExtensions).Assembly);
        }
    }
}
