namespace ZelmetErpSpec;

public enum ModuleCode
{
    M,
    P,
    U,
    D,
    Q,
    R,
    Z,
    A,
    DOD
}

public sealed record Module(ModuleCode Code, string Name, string Description);

public sealed record Actor(string Id, string Name, string Description, IReadOnlyList<string> Responsibilities, IReadOnlyList<string> Attributes);

public sealed record BusinessObject(string Id, string Name, string Description, IReadOnlyList<string> Attributes, IReadOnlyList<string> Relations);

public sealed record BusinessProcess(string Id, string Name, string Description, IReadOnlyList<string> Actors, IReadOnlyList<string> Steps);

public sealed record FunctionalRequirement(
    string Id,
    string Persona,
    string Module,
    string Description);

public sealed record NonFunctionalRequirement(
    string Id,
    string Category,
    string Description,
    IReadOnlyList<string> Constraints);

public sealed record SpecificationMetadata(
    string Version,
    DateOnly CreatedAt,
    DateOnly ModifiedAt,
    IReadOnlyList<string> Authors);

public sealed record SystemOverview(
    string Name,
    string Description,
    IReadOnlyList<string> KeyModules,
    IReadOnlyList<string> TargetAudiences,
    IReadOnlyList<string> BusinessBenefits);

public sealed record SpecificationDocument(
    SpecificationMetadata Metadata,
    SystemOverview Overview,
    IReadOnlyList<Module> Modules,
    IReadOnlyList<Actor> Actors,
    IReadOnlyList<BusinessObject> BusinessObjects,
    IReadOnlyList<BusinessProcess> BusinessProcesses,
    IReadOnlyList<FunctionalRequirement> FunctionalRequirements,
    IReadOnlyList<NonFunctionalRequirement> NonFunctionalRequirements);
