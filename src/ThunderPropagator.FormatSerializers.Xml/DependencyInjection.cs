using Ardalis.GuardClauses;
using Microsoft.Extensions.DependencyInjection;
using ThunderPropagator.BuildingBlocks.Application;

namespace ThunderPropagator.FormatSerializers.Xml
{
    /// <summary>
    /// Extension methods for registering ThunderPropagator BuildingBlocks services.
    /// </summary>
    public static class DependencyInjection
    {
        public static IServiceCollection AddXmlFormatSerializer(this IServiceCollection services)
        {
            Guard.Against.Null(services);
            services
                .AddFormatSerializer<XmlFormatSerializer>()
                .AddFormatDeserializer<XmlFormatSerializer>();

            return services;
        }
    }
}
