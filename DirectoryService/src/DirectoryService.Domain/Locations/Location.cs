using CSharpFunctionalExtensions;
using DirectoryService.Domain.Locations.ValueObjects;
using DirectoryService.Domain;

namespace DirectoryService.Domain.Locations;

public class Location: Shared.Entity<LocationId>
{
    // ef core
    private Location(LocationId id)
        : base(id) { }

    public LocationId Id { get; private set; }

    public LocationName Name { get; private set; }

    public LocationAddress Address { get; private set; }

    public LocationTimezone Timezone { get; private set; }

    public bool IsActive { get; private set; }

    public DateTime CreatedAt { get; private set; }

    public DateTime UpdatedAt { get; private set; }

    private Location(LocationId id, LocationName name, LocationTimezone timezone, LocationAddress address)
        : base(id)
    {
        Id = id;
        Name = name;
        Timezone = timezone;
        Address = address;
        IsActive = true;
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
    }

    public static Result<Location> Create(LocationName name, LocationAddress address)
    {
        var id = LocationId.NewLocationId();
        var timezone = LocationTimezone.Create(address.Continent, address.City).Value;
        return new Location(id, name, timezone, address);
    }
}