using OrganizationAssetManagement.Domain.Common;

namespace OrganizationAssetManagement.Domain.Entities;

public class OrganizationUnit : BaseEntity
{
    public string Name { get; set; } = string.Empty;

    public string? Description { get; set; }
}