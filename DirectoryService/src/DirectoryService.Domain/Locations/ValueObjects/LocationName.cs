using CSharpFunctionalExtensions;
using static DirectoryService.Domain.Shared.Constants;

namespace DirectoryService.Domain.Locations.ValueObjects;

public record LocationName
{
    private LocationName(string value)
    {
        Value = value;
    }

    public string Value { get; }

    public static Result<LocationName> Create(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            return Result.Failure<LocationName>("Name cannot be empty");
        if (input.Length < MIN_NAME_LENGTH || input.Length > MAX_LOCATION_NAME_LENGTH)
            return Result.Failure<LocationName>("Name must be between 3 and 120 characters");
        LocationName locationName = new(input);
        return locationName;
    }
}