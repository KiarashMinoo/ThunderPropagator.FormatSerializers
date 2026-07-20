using System.Diagnostics;
using ThunderPropagator.BuildingBlocks.Application;
using ThunderPropagator.BuildingBlocks.Application.Serializations;

namespace ThunderPropagator.FormatSerializers.Toon
{
    /// <summary>
    /// <see cref="IFormatSerializer"/> and <see cref="IFormatDeserializer"/> implementation
    /// backed by Toon-CSharp.
    /// String representations are Base64-encoded Toon bytes.
    /// </summary>
    public sealed class ToonFormatSerializer : IFormatSerializer, IFormatDeserializer
    {
        /// <summary>
        /// YamlDotNet — text/toon
        /// </summary>
        public static readonly SerializerType Toon = 8;

        /// <summary>text/toon</summary>
        public const string ToonMediaType = "text/toon";

        public SerializerType SerializerType => Toon;
        public string MediaType => ToonMediaType;

        /// <inheritdoc/>
        public string Serialize<T>(T instance)
        {
            const string activityName = $"{nameof(ToonFormatSerializer)}_{nameof(Serialize)}";
            using var activity = Telemetry.HasListeners() ? Telemetry.StartActivity(activityName, ActivityKind.Internal) : null;

            return instance.ToToonBase64();
        }

        /// <inheritdoc/>
        public byte[] SerializeToBytes<T>(T instance)
        {
            const string activityName = $"{nameof(ToonFormatSerializer)}_{nameof(SerializeToBytes)}";
            using var activity = Telemetry.HasListeners() ? Telemetry.StartActivity(activityName, ActivityKind.Internal) : null;

            return instance.ToToonBytes();
        }

        /// <inheritdoc/>
        public T? Deserialize<T>(string data)
        {
            const string activityName = $"{nameof(ToonFormatSerializer)}_{nameof(Deserialize)}";
            using var activity = Telemetry.HasListeners() ? Telemetry.StartActivity(activityName, ActivityKind.Internal) : null;

            if (string.IsNullOrWhiteSpace(data))
            {
                return default;
            }

            return data.FromToonBase64<T>();
        }

        /// <inheritdoc/>
        public T? Deserialize<T>(byte[] bytes)
        {
            const string activityName = $"{nameof(ToonFormatSerializer)}_{nameof(Deserialize)}";
            using var activity = Telemetry.HasListeners() ? Telemetry.StartActivity(activityName, ActivityKind.Internal) : null;

            if (bytes.Length == 0)
            {
                return default;
            }

            return bytes.FromToonBytes<T>();
        }
    }
}
