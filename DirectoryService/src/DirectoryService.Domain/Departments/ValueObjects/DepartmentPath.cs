using CSharpFunctionalExtensions;
using static DirectoryService.Domain.Shared.Constants;

namespace DirectoryService.Domain.Departments.ValueObjects;

public record DepartmentPath
{

    private DepartmentPath(string value)
    {
        Value = value;
    }

    public string Value { get; }

    public static Result<DepartmentPath> Create(params string[] input)
    {
        if (input.Length == 0 || input.Any(string.IsNullOrWhiteSpace))
            return Result.Failure<DepartmentPath>("Empty path");

        string departmentPath = string.Join(".", input);

        if (IsValidPath(departmentPath))
            return Result.Failure<DepartmentPath>("Latin letters only");

        return new DepartmentPath(departmentPath);
    }
}