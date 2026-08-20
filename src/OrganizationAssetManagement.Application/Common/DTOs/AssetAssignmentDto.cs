namespace OrganizationAssetManagement.Application.Common.DTOs;

public class AssetAssignmentDto
{
    public Guid Id { get; set; }

    public Guid AssetId { get; set; }

    public Guid UserId { get; set; }

    public DateTime AssignedAt { get; set; }

    public DateTime? ReturnedAt { get; set; }

    public bool IsActive => ReturnedAt == null;
}