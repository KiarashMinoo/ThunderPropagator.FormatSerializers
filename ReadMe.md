# ThunderPropagator Format Serializers

Format-specific .NET adapters for the ThunderPropagator serializer registry. The repository provides independently referenceable MessagePack, NetJSON, protobuf, TOON, XML, and YAML packages targeting .NET 8, .NET 9, and .NET 10.

<!-- repo-docs:start -->
## Documentation

The generated [documentation hub](docs/README.md) compares formats and links to API contracts, dependencies, diagrams, and usage recipes.

- [MessagePack](docs/MessagePack/README.md) `Types:3` `Files:5` `Diagrams:✓`
- [NetJSON](docs/NetJson/README.md) `Types:2` `Files:4` `Diagrams:✓`
- [Protobuf](docs/Protobuf/README.md) `Types:2` `Files:4` `Diagrams:✓`
- [TOON](docs/Toon/README.md) `Types:2` `Files:4` `Diagrams:✓`
- [XML](docs/Xml/README.md) `Types:2` `Files:4` `Diagrams:✓`
- [YAML](docs/Yaml/README.md) `Types:9` `Files:8` `Diagrams:✓`

### Package sources

No repository `NuGet.Config` is present. NuGet.org dependencies use the default feed. Configure GitHub Packages to restore the shared ThunderPropagator package:

```bash
dotnet nuget add source https://nuget.pkg.github.com/KiarashMinoo/index.json --name github --username YOUR_GITHUB_USERNAME --password YOUR_GITHUB_PAT --store-password-in-clear-text
dotnet restore
dotnet build -c Release
```

**Last generated:** July 20, 2026
<!-- repo-docs:end -->

## Packages

| Package | Format | Serializer ID | Media type | String representation |
|---|---|---:|---|---|
| `ThunderPropagator.FormatSerializers.MessagePack` | MessagePack | 5 | `application/x-msgpack` | Base64 |
| `ThunderPropagator.FormatSerializers.NetJson` | JSON | 3 | `application/json` | JSON |
| `ThunderPropagator.FormatSerializers.Protobuf` | Protocol Buffers | 4 | `application/x-protobuf` | Base64 |
| `ThunderPropagator.FormatSerializers.Toon` | TOON | 8 | `text/toon` | TOON |
| `ThunderPropagator.FormatSerializers.Xml` | XML | 6 | `application/xml` | XML |
| `ThunderPropagator.FormatSerializers.Yaml` | YAML | 7 | `application/yaml` | YAML |

All packages currently use repository version `1.0.1-beta.0`. Platform-specific and Debug package suffixes are supplied by the shared build configuration.

## Usage

Each module exposes extension methods for direct conversion. Binary formats use Base64 when a string is required by the common serializer contract.

```csharp
using ThunderPropagator.FormatSerializers.MessagePack;
using ThunderPropagator.FormatSerializers.NetJson;
using ThunderPropagator.FormatSerializers.Protobuf;
using ThunderPropagator.FormatSerializers.Toon;
using ThunderPropagator.FormatSerializers.Xml;
using ThunderPropagator.FormatSerializers.Yaml;

var messagePack = order.ToMessagePackBytes();
var json = order.ToNetJson();
var protobuf = order.ToProtobufBytes();
var toon = order.ToToon();
var xml = order.ToXml();
var yaml = order.ToYaml();
```

Restore typed values through the matching helpers:

```csharp
var fromMessagePack = messagePack.FromMessagePack<Order>();
var fromJson = json.FromNetJson<Order>();
var fromProtobuf = protobuf.FromProtobuf<Order>();
var fromToon = toon.FromToon<Order>();
var fromXml = xml.FromXml<Order>();
var fromYaml = yaml.FromYaml<Order>();
```

MessagePack also provides DI registration for both common format interfaces:

```csharp
services.AddMessagePackFormatSerializer();
```

## Shared behavior

- Format adapters implement `IFormatSerializer` and `IFormatDeserializer` from ThunderPropagator BuildingBlocks.
- Operations create tracing activities when the shared telemetry source has listeners.
- MessagePack, NetJSON, protobuf, XML, and YAML temporarily protect members recognized by `SensitiveDataEncryption` during serialization and decrypt them after deserialization.
- Empty input through a format adapter returns `default`; direct helpers otherwise expose codec-specific errors.
- Package versions are managed centrally in `Directory.Packages.props`.

See the [format comparison](docs/README.md#format-comparison) before choosing a wire representation.

## Build and test

The solution builds all six packages for .NET 8, .NET 9, and .NET 10. Tests currently run on .NET 10.

```bash
dotnet restore
dotnet build ThunderPropagator.FormatSerializers.slnx -c Release
dotnet test ThunderPropagator.FormatSerializers.slnx -c Release --no-build
dotnet pack ThunderPropagator.FormatSerializers.slnx -c Release -o artifacts/pkg
```

Supported solution platforms are Any CPU, x86, x64, and ARM64. Architecture tests enforce package independence and serializer-layer constraints; the unit suite covers helpers and the shared serializer registry behavior.

## Repository layout

```text
src/       Serializer package implementations
Tests/     Unit and architecture tests
docs/      Generated per-package documentation
.github/   CI, dependency, and security automation
```

## CI and security

GitHub Actions definitions cover build/test, dependency updates, static and dynamic analysis, penetration testing, and patch management. Review the workflows under `.github/workflows` before enabling repository secrets or deployment permissions.

## Contributing

1. Keep package-specific code isolated under its module.
2. Add or update tests for behavior changes.
3. Update the matching generated module README and catalog badges.
4. Run build and tests in Release configuration before opening a pull request.