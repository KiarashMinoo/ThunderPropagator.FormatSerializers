# CLAUDE.md

<!-- Humans: keep this file lean — the per-format template lives in .claude/rules/, not here. -->

## Commands

```powershell
dotnet restore
dotnet build -c Release
dotnet test -c Release
dotnet test --filter "FullyQualifiedName~<Name>"
dotnet pack -c Release -o artifacts/pkg
```

## Architecture

Flat set of sibling projects, one per serialization format, each depending only on an external shared building-blocks package (serializer/deserializer contracts + lookup registry) and that format's own serialization library. No local shared-kernel project — the shared contract lives upstream.

Per-format class template: `.claude/rules/format-template.md`.

## Conventions

- Wrap every serialize/deserialize call in a telemetry activity, guarded by a listener check.
- Guard-clause library for argument validation in DI registration methods.
- Nullable + implicit usings on; centrally managed package versions, TFMs, version.
- Shared package must never depend downward on any individual format project — architecture-test enforced.

## Adding a Format

New sibling project → serializer class (implements both upstream contracts) → static helper class (all four encode/decode combinations) → DI extension → unit tests (round-trip per combination) → architecture-test check confirming the shared package doesn't depend on the new project.

## Testing

xUnit + NSubstitute. Architecture-test project checks dependency direction between the shared package and each format project.

## Build & Versioning

Version/TFMs centralized; CI bumps automatically on a beta branch (prerelease, every push) and a release branch (finalizes version) — never hand-edit during feature work. Package versions centrally managed.
