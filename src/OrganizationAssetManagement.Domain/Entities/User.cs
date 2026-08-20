using OrganizationAssetManagement.Domain.Common;
using OrganizationAssetManagement.Domain.Enums;

namespace OrganizationAssetManagement.Domain.Entities;

public class User : BaseEntity
{
    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string PasswordHash { get; set; } = string.Empty;

    public UserRole Role { get; set; }

    public Guid? OrganizationUnitId { get; set; }

    public OrganizationUnit? OrganizationUnit { get; set; }
}