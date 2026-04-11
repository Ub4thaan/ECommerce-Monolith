namespace Application.Errors;

public sealed record ValidationError(Error[] Errors)
    : Error("Validation", "One or more validation errors occurred.", ErrorType.Validation);
