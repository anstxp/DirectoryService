using CSharpFunctionalExtensions;
using DirectoryService.Domain.Departments.ValueObjects;
using DirectoryService.Domain.Locations;
using DirectoryService.Domain.Locations.ValueObjects;

namespace DirectoryService.Domain.Departments;

public class DepartmentLocation: Shared.Entity<DepartmentLocationId>
{
    private DepartmentLocation(DepartmentLocationId id)
        : base(id) { }

    public DepartmentLocationId Id { get; private set; }

    public LocationId LocationId { get; private set; }

    public DepartmentId DepartmentId { get; private set; }

    public Department? Department { get; private set; }

    public Location? Location { get; private set; }

    private DepartmentLocation(
        DepartmentLocationId id,
        LocationId locationId,
        DepartmentId departmentId)
        : this(id)
    {
        LocationId = locationId;
        DepartmentId = departmentId;
    }

    public static Result<DepartmentLocation> Create(LocationId locationId, DepartmentId departmentId)
    {
        var id = DepartmentLocationId.NewId();
        return new DepartmentLocation(id,  locationId, departmentId);
    }
}