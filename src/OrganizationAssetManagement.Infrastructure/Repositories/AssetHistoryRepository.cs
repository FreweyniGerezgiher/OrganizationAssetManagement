using Microsoft.EntityFrameworkCore;
using OrganizationAssetManagement.Application.Common.Interfaces;
using OrganizationAssetManagement.Domain.Entities;
using OrganizationAssetManagement.Infrastructure.Persistence;

namespace OrganizationAssetManagement.Infrastructure.Repositories;

public class AssetHistoryRepository : IAssetHistoryRepository
{
    private readonly ApplicationDbContext _context;

    public AssetHistoryRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(AssetHistory history)
    {
        await _context.AssetHistories.AddAsync(history);

        await _context.SaveChangesAsync();
    }

    public async Task<List<AssetHistory>> GetByAssetIdAsync(Guid assetId)
    {
        return await _context.AssetHistories
            .Where(x => x.AssetId == assetId)
            .OrderByDescending(x => x.ActionDate)
            .ToListAsync();
    }
}