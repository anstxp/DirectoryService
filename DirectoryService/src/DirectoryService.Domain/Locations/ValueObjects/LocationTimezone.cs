using CSharpFunctionalExtensions;
using static DirectoryService.Domain.Shared.Constants;

namespace DirectoryService.Domain.Locations.ValueObjects;

public record LocationTimezone
{
    private LocationTimezone(string iana)
    {
        IANA = iana;
    }

    public string IANA { get; }

    public static Result<LocationTimezone> Create(string continent, string city)
    {
        if (string.IsNullOrWhiteSpace(continent) || string.IsNullOrWhiteSpace(city))
            return Result.Failure<LocationTimezone>("Empty parameters");
        var timezone = string.Join("/", continent, city);
        if (IsIanaTz(timezone))
            return Result.Failure<LocationTimezone>("LocationTimezone is not valid");

        return new LocationTimezone(timezone);
    }
}