# Contributing

## Prerequisites

Install the [.NET 10 SDK](https://learn.microsoft.com/en-us/dotnet/core/install/).

## Build and test

Build the solution and run the xUnit test suite:

```bash
dotnet restore ./src
dotnet build ./src --no-restore
dotnet test ./src --no-build --verbosity normal
```

The `Release` configuration in `src/Reportify/Reportify.csproj` publishes a
self-contained single-file executable.

## Repository layout

- `src/Reportify` contains the CLI application.
- `src/Reportify.Tests` contains the xUnit tests and test fixtures.
- `doc` contains documentation and images.

## Pull requests

1. Fork the repository and create a branch from `main`.
2. Make your changes and add or update tests as needed.
3. Run `dotnet test ./src` to confirm all tests pass.
4. Open a pull request against `main`.

## Credits

reportify was created by [Francisco Metzger](https://github.com/francWhite) and
is maintained by [@kevinboss](https://github.com/kevinboss).
