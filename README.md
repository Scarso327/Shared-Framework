# Shared Framework
Contains a generic base to be used with .NET projects. It was created for Clean/Onion Architecture apps but could in theory be used for anything. 
All projects are split into folders about their expected layer, this has been done with actual folders and not just the solution for VSCode users.

It is very much a work-in-progress framework and could see large changes as I continue to use it for personal projects. Tests will also be added in the future.

## Layers

### Core
Core contains projects relating to your Domain and Application layers.

### Infrastructure
Matches the same layer in Clean Architecture. Mainly implementations from the Domain layer.

### Presentation
Same as Infrastructure, it contains further implementations from the previous layers and this is where you'd find direct dependency on AspNetCore.

## References
- [Clean Architecture (Microsoft)](https://learn.microsoft.com/en-us/dotnet/architecture/modern-web-apps-azure/common-web-application-architectures#clean-architecture)
