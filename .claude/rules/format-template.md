---
paths:
  - "src/ThunderPropagator.FormatSerializers.MessagePack/**"
  - "src/ThunderPropagator.FormatSerializers.NetJson/**"
  - "src/ThunderPropagator.FormatSerializers.Protobuf/**"
  - "src/ThunderPropagator.FormatSerializers.Toon/**"
  - "src/ThunderPropagator.FormatSerializers.Xml/**"
  - "src/ThunderPropagator.FormatSerializers.Yaml/**"
---

# Per-Format Template

- **`{Format}FormatSerializer`** — sealed, implements both serializer and deserializer contracts from the shared package. Static serializer-type identifier + media-type constant.
- **`{Format}Helper`** — static class, encode/decode methods: string, bytes, base64, both directions.
- **`DependencyInjection`** — static class, one `Add{Format}FormatSerializer(IServiceCollection)` extension registering the serializer against both contract interfaces.

```csharp
public static IServiceCollection Add{Format}FormatSerializer(this IServiceCollection services)
{
    Guard.Against.Null(services);
    services.AddSingleton<IFormatSerializer, {Format}FormatSerializer>();
    services.AddSingleton<IFormatDeserializer, {Format}FormatSerializer>();
    return services;
}
```
