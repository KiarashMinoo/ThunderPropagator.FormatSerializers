using Ardalis.GuardClauses;
using Microsoft.Extensions.DependencyInjection;
using ThunderPropagator.BuildingBlocks.Application;

namespace ThunderPropagator.FormatSerializers.MessagePack
{
    /// <summary>
    /// Extension methods for registering ThunderPropagator BuildingBlocks services.
    /// </summary>
    public static class DependencyInjection
    {
        public static IServiceCollection AddMessagePackFormatSerializer(this IServiceCollection services)
        {
            Guard.Against.Null(services);
            services
                .AddFormatSerializer<MessagePackFormatSerializer>()
                .AddFormatDeserializer<MessagePackFormatSerializer>();

            return services;
        }
    }
}
