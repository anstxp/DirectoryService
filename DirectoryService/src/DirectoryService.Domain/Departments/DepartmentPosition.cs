using CSharpFunctionalExtensions;
using DirectoryService.Domain.Departments.ValueObjects;
using DirectoryService.Domain.Positions;
using DirectoryService.Domain.Positions.ValueObjects;

namespace DirectoryService.Domain.Departments;

public class DepartmentPosition: Shared.Entity<DepartmentPositionId>
{
    private DepartmentPosition(DepartmentPositionId id)
        : base(id) { }

    public DepartmentPositionId Id { get; private set; }

    public PositionId PositionId { get; private set; }

    public DepartmentId DepartmentId { get; private set; }

    public Department? Department { get; private set; }

    public Position? Position { get; private set; }

    private DepartmentPosition(
        DepartmentPositionId id,
        PositionId positionId,
        DepartmentId departmentId)
        : this(id)
    {
        PositionId = positionId;
        DepartmentId = departmentId;
    }

    public static Result<DepartmentPosition> Create(PositionId positionId, DepartmentId departmentId)
    {
        var id = DepartmentPositionId.NewId();
        return new DepartmentPosition(id,  positionId, departmentId);
    }
}