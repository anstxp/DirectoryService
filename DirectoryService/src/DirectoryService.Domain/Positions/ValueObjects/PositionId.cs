namespace DirectoryService.Domain.Positions.ValueObjects;

public record PositionId
{
    private PositionId(Guid value)
    {
        Value = value;
    }

    public Guid Value { get; }
    public static PositionId NewPositionId() => new(Guid.NewGuid());
    public static PositionId Empty() => new(Guid.Empty);
}