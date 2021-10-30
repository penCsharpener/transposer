using Microsoft.Extensions.DependencyInjection;

namespace Transposer.Blazor.Shared.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddSharedDependencies(this IServiceCollection services)
        {
            services.AddScoped(_ => new Transposer.SmartChord.Transposer.Transposer());

            return services;
        }
    }
}
