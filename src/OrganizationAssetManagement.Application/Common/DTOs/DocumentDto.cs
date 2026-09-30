namespace OrganizationAssetManagement.Application.Common.DTOs;

public class DocumentDto
{
    public Guid Id { get; set; }

    public string FileName { get; set; } = string.Empty;

    public string FilePath { get; set; } = string.Empty;

    public string? ContentType { get; set; }

    public Guid? AssetId { get; set; }

    public DateTime CreatedAt { get; set; }
}