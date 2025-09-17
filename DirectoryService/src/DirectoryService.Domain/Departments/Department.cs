using CSharpFunctionalExtensions;
using DirectoryService.Domain.Departments.ValueObjects;
using DirectoryService.Domain.Shared;

namespace DirectoryService.Domain.Departments;

public class Department : Shared.Entity<DepartmentId>
{
    private Department(DepartmentId id)
        : base(id) { }

    private Department(
        DepartmentId id,
        DepartmentName departmentName,
        DepartmentIdentifier departmentIdentifier,
        Department? parent,
        DepartmentPath path,
        IEnumerable<DepartmentLocation>? departmentLocations)
        : base(id)
    {
        Id = id;
        DepartmentName = departmentName;
        DepartmentIdentifier = departmentIdentifier;
        Parent = parent;
        IsActive = true;
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
        DepartmentPath = path;
        _departmentLocations = departmentLocations.ToList();
    }

    private List<Department> _childrenDepartments = [];
    private List<DepartmentLocation> _departmentLocations = [];
    private List<DepartmentPosition> _departmentPositions = [];

    public DepartmentId Id { get; private set; }

    public DepartmentName DepartmentName { get; private set; }

    public DepartmentIdentifier DepartmentIdentifier { get; private set; }

    public Department? Parent { get; private set; }

    public DepartmentPath DepartmentPath {get; private set;  }

    public short Depth { get; private set; }

    public bool IsActive { get; private set; }

    public DateTime CreatedAt { get; private set; }

    public DateTime UpdatedAt { get; private set; }

    public IReadOnlyList<Department> ChildrenDepartments => _childrenDepartments;

    public IReadOnlyList<DepartmentLocation> DepartmentLocations => _departmentLocations;

    public IReadOnlyList<DepartmentPosition> DepartmentPositions => _departmentPositions;


    public static Result<Department> Create(
        DepartmentName name,
        DepartmentIdentifier identifier,
        Department? parent,
        List<DepartmentLocation> locations)
    {
        var id = DepartmentId.NewDepartmentId();

        var path = parent is null
            ? DepartmentPath.Create(identifier.Value).Value
            : DepartmentPath.Create(parent.DepartmentPath.Value, identifier.Value).Value;

        short depth = (short)(parent?.Depth + 1 ?? 0);

        return new Department(id, name, identifier, parent, path, locations);
    }
}