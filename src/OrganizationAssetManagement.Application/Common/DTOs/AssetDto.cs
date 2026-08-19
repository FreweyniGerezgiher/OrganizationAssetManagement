namespace OrganizationAssetManagement.Application.Common.Models;

public class AssetDto
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string AssetTag { get; set; } = string.Empty;

    public string SerialNumber { get; set; } = string.Empty;

    public string? Description { get; set; }

    public string Status { get; set; } = string.Empty;
}