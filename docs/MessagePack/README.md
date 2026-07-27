# MessagePack

## Contents

- [Overview](#overview)
- [Files](#files)
- [Types and Members](#types-and-members)
- [Serialization and Contracts](#serialization-and-contracts)
- [Validation and Constraints](#validation-and-constraints)
- [Package Dependencies](#package-dependencies)
- [Diagrams](#diagrams)
- [Examples](#examples)
- [See Also](#see-also)

## Overview

The **MessagePack** area groups 3 documented types, including `DependencyInjection`, `MessagePackFormatSerializer`, `MessagePackHelper`. It provides the contracts and implementation used by this part of ThunderPropagator.FormatSerializers.

## Files

| File | Primary type(s)/symbol(s) | LOC (approx.) | Responsibility |
|---|---|---:|---|
| `AssemblyInfo.cs` | — | 4 | Contains the assembly info implementation or configuration. |
| `DependencyInjection.cs` | `DependencyInjection` | 22 | Defines DependencyInjection and its related behavior. |
| `MessagePackFormatSerializer.cs` | `MessagePackFormatSerializer` | 71 | Defines MessagePackFormatSerializer and its related behavior. |
| `MessagePackHelper.cs` | `MessagePackHelper` | 110 | Defines MessagePackHelper and its related behavior. |
| `ThunderPropagator.FormatSerializers.MessagePack.csproj` | — | 12 | Defines project build targets, dependencies, and package metadata. |

## Types and Members

| Type | Kind | Summary | Inherits/Implements | Key Members |
|---|---|---|---|---|
| [`DependencyInjection`](#dependencyinjection) | class | Extension methods for registering ThunderPropagator BuildingBlocks services. | — | `AddMessagePackFormatSerializer(…)` |
| [`MessagePackFormatSerializer`](#messagepackformatserializer) | class | and implementation backed by MessagePack-CSharp. String representations are Base64-encoded MessagePack bytes. | `IFormatSerializer, IFormatDeserializer` | `SerializerType`, `MediaType` |
| [`MessagePackHelper`](#messagepackhelper) | class | Represents the MessagePackHelper class. | — | — |

### DependencyInjection

- **Kind:** class
- **Namespace:** `ThunderPropagator.FormatSerializers.MessagePack`
- **Inherits/implements:** None declared
- **Attributes:** None detected
- **Key members:** `AddMessagePackFormatSerializer(…)`
- **Summary:** Extension methods for registering ThunderPropagator BuildingBlocks services.
- **Thread safety:** Follow the lifetime and concurrency guarantees of the owning component; no additional guarantee is inferred.

**Usage recipe**

```csharp
// Resolve DependencyInjection from the configured service container or construct it with its declared dependencies.
```

[↑ Back to top](#contents)

### MessagePackFormatSerializer

- **Kind:** class
- **Namespace:** `ThunderPropagator.FormatSerializers.MessagePack`
- **Inherits/implements:** `IFormatSerializer, IFormatDeserializer`
- **Attributes:** None detected
- **Key members:** `SerializerType`, `MediaType`
- **Summary:** and implementation backed by MessagePack-CSharp. String representations are Base64-encoded MessagePack bytes.
- **Thread safety:** Follow the lifetime and concurrency guarantees of the owning component; no additional guarantee is inferred.

**Usage recipe**

```csharp
// Resolve MessagePackFormatSerializer from the configured service container or construct it with its declared dependencies.
```

[↑ Back to top](#contents)

### MessagePackHelper

- **Kind:** class
- **Namespace:** `ThunderPropagator.FormatSerializers.MessagePack`
- **Inherits/implements:** None declared
- **Attributes:** None detected
- **Key members:** Refer to the API surface in the source package
- **Summary:** Represents the MessagePackHelper class.
- **Thread safety:** Follow the lifetime and concurrency guarantees of the owning component; no additional guarantee is inferred.

**Usage recipe**

```csharp
// Resolve MessagePackHelper from the configured service container or construct it with its declared dependencies.
```

[↑ Back to top](#contents)

## Serialization and Contracts

Serialization behavior is part of the public wire or persistence contract in this area. Preserve field names, ordering rules, content negotiation, and backward-compatibility expectations when changing these types.

## Validation and Constraints

Inputs are validated at component boundaries. Callers should provide non-null required values and handle domain or argument exceptions without retrying invalid requests unchanged.

## Package Dependencies

| Package | Version | Description | Links |
|---|---|---|---|
| `MessagePack` | `3.1.8` | External dependency used by the repository. | [Registry](https://www.nuget.org/packages/MessagePack) |
| `MessagePackAnalyzer` | `3.1.8` | External dependency used by the repository. | [Registry](https://www.nuget.org/packages/MessagePackAnalyzer) |
| `NetJSON` | `1.4.5` | External dependency used by the repository. | [Registry](https://www.nuget.org/packages/NetJSON) |
| `protobuf-net` | `3.2.56` | External dependency used by the repository. | [Registry](https://www.nuget.org/packages/protobuf-net) |
| `ToonNet` | `1.0.4` | External dependency used by the repository. | [Registry](https://www.nuget.org/packages/ToonNet) |
| `YamlDotNet` | `18.1.0` | External dependency used by the repository. | [Registry](https://www.nuget.org/packages/YamlDotNet) |

## Diagrams

### Component overview

```mermaid
graph TD
  Current["MessagePack"]
  Current --> T0["DependencyInjection"]
  Current --> T1["MessagePackFormatSerializer"]
  Current --> T2["MessagePackHelper"]
```

The diagram shows the direct components documented by the **MessagePack** area.

## Examples

Start with `DependencyInjection` as the primary entry point for this folder, then follow its linked contracts and collaborators.

## See Also

- [Documentation home](../README.md)
- [NetJson](../NetJson/README.md)
- [Protobuf](../Protobuf/README.md)
- [Toon](../Toon/README.md)
- [Xml](../Xml/README.md)
- [Yaml](../Yaml/README.md)

[↑ Back to top](#contents)
