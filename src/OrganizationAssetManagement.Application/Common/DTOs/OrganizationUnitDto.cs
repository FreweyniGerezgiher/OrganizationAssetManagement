namespace OrganizationAssetManagement.Application.Common.Models;

public class OrganizationUnitDto
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string? Description { get; set; }
}