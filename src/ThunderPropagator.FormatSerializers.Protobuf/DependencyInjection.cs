using Ardalis.GuardClauses;
using Microsoft.Extensions.DependencyInjection;
using ThunderPropagator.BuildingBlocks.Application;

namespace ThunderPropagator.FormatSerializers.Protobuf
{
    /// <summary>
    /// Extension methods for registering ThunderPropagator BuildingBlocks services.
    /// </summary>
    public static class DependencyInjection
    {
        public static IServiceCollection AddProtobufFormatSerializer(this IServiceCollection services)
        {
            Guard.Against.Null(services);
            services
                .AddFormatSerializer<ProtobufFormatSerializer>()
                .AddFormatDeserializer<ProtobufFormatSerializer>();

            return services;
        }
    }
}
