using OrganizationAssetManagement.Domain.Common;

namespace OrganizationAssetManagement.Domain.Entities;

public class AssetAssignment : BaseEntity
{
    public Guid AssetId { get; set; }

    public Asset? Asset { get; set; }

    public Guid UserId { get; set; }

    public User? User { get; set; }

    public DateTime AssignedAt { get; set; }

    public DateTime? ReturnedAt { get; set; }
}