using OrganizationAssetManagement.Domain.Entities;

namespace OrganizationAssetManagement.Application.Common.Interfaces;

public interface IAssetAssignmentRepository
{
    Task<AssetAssignment?> GetByIdAsync(Guid id);

    Task<AssetAssignment?> GetActiveByAssetIdAsync(Guid assetId);

    Task<List<AssetAssignment>> GetByAssetIdAsync(Guid assetId);

    Task AddAsync(AssetAssignment assignment);

    Task UpdateAsync(AssetAssignment assignment);
}