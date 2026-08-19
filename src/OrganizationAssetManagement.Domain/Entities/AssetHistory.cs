using OrganizationAssetManagement.Domain.Common;

namespace OrganizationAssetManagement.Domain.Entities;

public class AssetHistory : BaseEntity
{
    public Guid AssetId { get; set; }

    public Asset? Asset { get; set; }

    public string Action { get; set; } = string.Empty;

    public string? Description { get; set; }

    public DateTime ActionDate { get; set; }
}