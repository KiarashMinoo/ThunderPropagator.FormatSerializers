# CLAUDE.md

Guidance for working in this repository.

## Commands

```powershell
dotnet restore
dotnet build -c Release
dotnet test -c Release
dotnet test --filter "FullyQualifiedName~<Name>"
dotnet pack -c Release -o artifacts/pkg
```

## Architecture

A flat set of sibling projects, one per serialization format, each depending only on an external shared building-blocks package (for the serializer/deserializer contracts and a lookup registry) and that format's own serialization library. There is no local shared-kernel project — the shared contract lives upstream.

## The per-format template

Every format project follows the same shape:

- **`{Format}FormatSerializer`** — sealed, implements both the serializer and deserializer contracts from the shared package. Exposes a static serializer-type identifier and a media-type constant.
- **`{Format}Helper`** — static class with the actual encode/decode methods: string, bytes, and base64, both directions.
- **`DependencyInjection`** — static class exposing one `Add{Format}FormatSerializer(IServiceCollection)` extension that registers the serializer against both contract interfaces.

```csharp
public static IServiceCollection Add{Format}FormatSerializer(this IServiceCollection services)
{
    Guard.Against.Null(services);
    services.AddSingleton<IFormatSerializer, {Format}FormatSerializer>();
    services.AddSingleton<IFormatDeserializer, {Format}FormatSerializer>();
    return services;
}
```

## Conventions

- Wrap every serialize/deserialize call in a telemetry activity, guarded by a listener check.
- Guard-clause library for argument validation in DI registration methods.
- Nullable + implicit usings on; centrally managed package versions; centrally managed target frameworks and version.
- The shared package must never depend downward on any individual format project — an architecture test enforces this direction.

## Adding a format

New sibling project → the serializer class implementing both upstream contracts → the static helper class with all four encode/decode combinations → the DI extension → unit tests covering round-trip serialization for each combination → an architecture-test check confirming the new project isn't depended on from the shared package.

## Testing

xUnit + NSubstitute. A separate architecture-test project checks the dependency direction between the shared package and each format project.

## Build & versioning

Version and target frameworks are centralized; CI bumps automatically on a beta branch (prerelease, every push) and a release branch (finalizes the version) — never hand-edit during feature work. Package versions are centrally managed.
