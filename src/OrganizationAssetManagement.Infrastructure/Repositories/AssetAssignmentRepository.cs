using Microsoft.EntityFrameworkCore;
using OrganizationAssetManagement.Application.Common.Interfaces;
using OrganizationAssetManagement.Domain.Entities;
using OrganizationAssetManagement.Infrastructure.Persistence;

namespace OrganizationAssetManagement.Infrastructure.Repositories;

public class AssetAssignmentRepository : IAssetAssignmentRepository
{
    private readonly ApplicationDbContext _context;

    public AssetAssignmentRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<AssetAssignment?> GetByIdAsync(Guid id)
    {
        return await _context.AssetAssignments
            .Include(x => x.Asset)
            .Include(x => x.User)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<AssetAssignment?> GetActiveByAssetIdAsync(Guid assetId)
    {
        return await _context.AssetAssignments
            .Include(x => x.Asset)
            .Include(x => x.User)
            .FirstOrDefaultAsync(x =>
                x.AssetId == assetId &&
                x.ReturnedAt == null);
    }

    public async Task<List<AssetAssignment>> GetByAssetIdAsync(Guid assetId)
    {
        return await _context.AssetAssignments
            .Include(x => x.User)
            .Where(x => x.AssetId == assetId)
            .OrderByDescending(x => x.AssignedAt)
            .ToListAsync();
    }

    public async Task AddAsync(AssetAssignment assignment)
    {
        await _context.AssetAssignments.AddAsync(assignment);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(AssetAssignment assignment)
    {
        _context.AssetAssignments.Update(assignment);
        await _context.SaveChangesAsync();
    }
}