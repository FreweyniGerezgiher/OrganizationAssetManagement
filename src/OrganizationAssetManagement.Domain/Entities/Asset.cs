using OrganizationAssetManagement.Domain.Common;
using OrganizationAssetManagement.Domain.Enums;

namespace OrganizationAssetManagement.Domain.Entities;

public class Asset : BaseEntity
{
    public string Name { get; set; } = string.Empty;

    public string AssetTag { get; set; } = string.Empty;

    public string SerialNumber { get; set; } = string.Empty;

    public string? Description { get; set; }

    public AssetStatus Status { get; set; }

    public Guid? OrganizationUnitId { get; set; }

    public OrganizationUnit? OrganizationUnit { get; set; }
}