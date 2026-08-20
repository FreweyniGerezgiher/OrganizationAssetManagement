using OrganizationAssetManagement.Domain.Entities;

namespace OrganizationAssetManagement.Application.Common.Interfaces;

public interface IJwtService
{
    string GenerateToken(User user);
}