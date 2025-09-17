using System.Runtime.InteropServices.Marshalling;
using CSharpFunctionalExtensions;
using DirectoryService.Domain.Positions.ValueObjects;

namespace DirectoryService.Domain.Positions;

public class Position: Shared.Entity<PositionId>
{
    private Position(PositionId id)
        : base(id) { }

    private Position(PositionId id, PositionData data)
        : base(id)
    {
        Data = data;
        isActive = true;
        CreatedAt = DateTime.UtcNow;
        UpdateAt = DateTime.UtcNow;
    }

    public PositionId Id { get; private set; }

    public PositionData Data { get; private set; }

    public bool isActive { get; private set; }

    public DateTime CreatedAt {get; private set; }

    public DateTime UpdateAt {get; private set; }

    public static Result<Position> Create(PositionData data)
    {
        var id = PositionId.NewPositionId();
        return new Position(id, data);
    }

}