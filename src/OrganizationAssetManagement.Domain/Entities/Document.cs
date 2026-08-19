using OrganizationAssetManagement.Domain.Common;

namespace OrganizationAssetManagement.Domain.Entities;

public class Document : BaseEntity
{
    public string FileName { get; set; } = string.Empty;

    public string FilePath { get; set; } = string.Empty;

    public string? ContentType { get; set; }

    public Guid? AssetId { get; set; }

    public Asset? Asset { get; set; }
}