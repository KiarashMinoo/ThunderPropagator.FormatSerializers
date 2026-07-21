using Ardalis.GuardClauses;
using Microsoft.Extensions.DependencyInjection;
using ThunderPropagator.BuildingBlocks.Application;

namespace ThunderPropagator.FormatSerializers.Yaml
{
    /// <summary>
    /// Extension methods for registering ThunderPropagator BuildingBlocks services.
    /// </summary>
    public static class DependencyInjection
    {
        public static IServiceCollection AddYamlFormatSerializer(this IServiceCollection services)
        {
            Guard.Against.Null(services);
            services
                .AddFormatSerializer<YamlFormatSerializer>()
                .AddFormatDeserializer<YamlFormatSerializer>();

            return services;
        }
    }
}
