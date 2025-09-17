namespace DirectoryService.Domain.Locations.ValueObjects;

public record LocationId
{
    private LocationId(Guid value)
    {
        Value = value;
    }

    public Guid Value { get; }
    public static LocationId NewLocationId() => new(Guid.NewGuid());
    public static LocationId Empty() => new(Guid.Empty);
}