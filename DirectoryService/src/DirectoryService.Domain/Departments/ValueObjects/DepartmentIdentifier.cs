using CSharpFunctionalExtensions;
using static DirectoryService.Domain.Shared.Constants;

namespace DirectoryService.Domain.Departments.ValueObjects;

public record DepartmentIdentifier
{
    private DepartmentIdentifier(string value)
    {
        Value = value;
    }

    public string Value { get; }

    public static Result<DepartmentIdentifier> Create(string input)
    {
        string trimmed = input.Trim();
        if(string.IsNullOrWhiteSpace(input))
            return Result.Failure<DepartmentIdentifier>("Identifier is empty");
        if(trimmed.Length < MIN_ID_LENGTH || trimmed.Length > MAX_ID_LENGTH)
            return Result.Failure<DepartmentIdentifier>("Identifier must be between 3 and 150 characters");
        if(IsValidIdentifier(trimmed))
            return Result.Failure<DepartmentIdentifier>("Latin letters only");
        var identifier = new DepartmentIdentifier(input);
        return identifier;
    }
}