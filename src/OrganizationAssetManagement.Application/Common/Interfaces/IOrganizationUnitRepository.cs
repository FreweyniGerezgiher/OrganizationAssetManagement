using OrganizationAssetManagement.Domain.Entities;

namespace OrganizationAssetManagement.Application.Common.Interfaces;

public interface IOrganizationUnitRepository
{
    Task<OrganizationUnit?> GetByIdAsync(Guid id);

    Task<List<OrganizationUnit>> GetAllAsync();

    Task AddAsync(OrganizationUnit organizationUnit);

    Task UpdateAsync(OrganizationUnit organizationUnit);

    Task DeleteAsync(OrganizationUnit organizationUnit);
}