namespace OrganizationAssetManagement.Application.Common.DTOs;

public class AssetHistoryDto
{
    public Guid Id { get; set; }

    public Guid AssetId { get; set; }

    public string Action { get; set; } = string.Empty;

    public string? Description { get; set; }

    public DateTime ActionDate { get; set; }
}