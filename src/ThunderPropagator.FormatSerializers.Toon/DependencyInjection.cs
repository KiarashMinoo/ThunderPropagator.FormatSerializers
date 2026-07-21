using Ardalis.GuardClauses;
using Microsoft.Extensions.DependencyInjection;
using ThunderPropagator.BuildingBlocks.Application;

namespace ThunderPropagator.FormatSerializers.Toon
{
    /// <summary>
    /// Extension methods for registering ThunderPropagator BuildingBlocks services.
    /// </summary>
    public static class DependencyInjection
    {
        public static IServiceCollection AddToonFormatSerializer(this IServiceCollection services)
        {
            Guard.Against.Null(services);
            services
                .AddFormatSerializer<ToonFormatSerializer>()
                .AddFormatDeserializer<ToonFormatSerializer>();

            return services;
        }
    }
}
