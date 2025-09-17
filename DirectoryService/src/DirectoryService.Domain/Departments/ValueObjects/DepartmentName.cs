using CSharpFunctionalExtensions;
using static DirectoryService.Domain.Shared.Constants;

namespace DirectoryService.Domain.Departments.ValueObjects;

public record DepartmentName
{
    private DepartmentName(string value)
    {
        Value = value;
    }

    public string Value { get; }

    public static Result<DepartmentName> Create(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            return Result.Failure<DepartmentName>("Name cannot be empty");
        if (input.Length < MIN_NAME_LENGTH || input.Length > MAX_DEP_NAME_LENGTH)
            return Result.Failure<DepartmentName>("Name must be between 3 and 150 characters");
        DepartmentName departmentName = new(input);
        return departmentName;
    }
}