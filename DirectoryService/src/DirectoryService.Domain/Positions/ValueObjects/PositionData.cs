using CSharpFunctionalExtensions;
using static DirectoryService.Domain.Shared.Constants;
namespace DirectoryService.Domain.Positions.ValueObjects;

public record PositionData
{
    private PositionData(string name, string? description)
    {
        Name = name;
        Description = description;
    }

    public string Name { get; }
    public string? Description { get; }


    public static Result<PositionData> Create(string name, string description)
    {
        if (string.IsNullOrWhiteSpace(name))
            return Result.Failure<PositionData>("Position name cannot be empty");
        if(name.Length < MIN_NAME_LENGTH || name.Length > MAX_POSITION_NAME_LENGTH)
            return Result.Failure<PositionData>("Position name must be between 3 and 100 characters");
        if(description.Length > MAX_TEXT_LENGTH)
            return Result.Failure<PositionData>("Position description cannot be longer than 100 characters");
        return new PositionData(name, description);
    }
}