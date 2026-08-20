using OrganizationAssetManagement.Domain.Common;

namespace OrganizationAssetManagement.Domain.Entities;

public class OrganizationUnit : BaseEntity
{
    public string Name { get; set; } = string.Empty;

    public string? Description { get; set; }

    public Guid? ParentOrganizationUnitId { get; set; }

    public OrganizationUnit? ParentOrganizationUnit { get; set; }

    public List<OrganizationUnit> Children { get; set; } = new();
}