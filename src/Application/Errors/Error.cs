namespace Application.Errors;

public record Error(string Code, string Description, ErrorType Type)
{
    public static readonly Error None = new(string.Empty, string.Empty, ErrorType.Unknown);

    private static readonly Error DefaultUnknown = new("General.Unknown", "An unexpected error occurred. Please contact support if the issue persists.", ErrorType.Unknown);
    private static readonly Error DefaultFailure = new("General.Failure", "The operation could not be completed. Please try again.", ErrorType.Failure);
    private static readonly Error DefaultValidation = new("General.Validation", "One or more validation rules were not satisfied.", ErrorType.Validation);
    private static readonly Error DefaultProblem = new("General.Problem", "A problem was encountered while processing the request.", ErrorType.Problem);
    private static readonly Error DefaultNotFound = new("General.NotFound", "The requested resource was not found.", ErrorType.NotFound);
    private static readonly Error DefaultConflict = new("General.Conflict", "A conflict occurred with the current state of the resource.", ErrorType.Conflict);
    private static readonly Error DefaultInternal = new("General.Internal", "An internal server error occurred. Please contact support if the issue persists.", ErrorType.Internal);

    public static Error Unknown(string code, string description) => new(code, description, ErrorType.Unknown);
    public static Error Unknown(string description) => new("General.Unknown", description, ErrorType.Unknown);
    public static Error Unknown() => DefaultUnknown;
    public static Error Failure(string code, string description) => new(code, description, ErrorType.Failure);
    public static Error Failure(string description) => new("General.Failure", description, ErrorType.Failure);
    public static Error Failure() => DefaultFailure;
    public static Error Validation(string code, string description) => new(code, description, ErrorType.Validation);
    public static Error Validation(string description) => new("General.Validation", description, ErrorType.Validation);
    public static Error Validation() => DefaultValidation;
    public static Error Problem(string code, string description) => new(code, description, ErrorType.Problem);
    public static Error Problem(string description) => new("General.Problem", description, ErrorType.Problem);
    public static Error Problem() => DefaultProblem;
    public static Error NotFound(string code, string description) => new(code, description, ErrorType.NotFound);
    public static Error NotFound(string description) => new("General.NotFound", description, ErrorType.NotFound);
    public static Error NotFound() => DefaultNotFound;
    public static Error Conflict(string code, string description) => new(code, description, ErrorType.Conflict);
    public static Error Conflict(string description) => new("General.Conflict", description, ErrorType.Conflict);
    public static Error Conflict() => DefaultConflict;
    public static Error Internal(string code, string description) => new(code, description, ErrorType.Internal);
    public static Error Internal(string description) => new("General.Internal", description, ErrorType.Internal);
    public static Error Internal() => DefaultInternal;
}
