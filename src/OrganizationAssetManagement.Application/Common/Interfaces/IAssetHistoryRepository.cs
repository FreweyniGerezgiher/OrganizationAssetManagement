using OrganizationAssetManagement.Domain.Entities;

namespace OrganizationAssetManagement.Application.Common.Interfaces;

public interface IAssetHistoryRepository
{
    Task AddAsync(AssetHistory history);

    Task<List<AssetHistory>> GetByAssetIdAsync(Guid assetId);
}