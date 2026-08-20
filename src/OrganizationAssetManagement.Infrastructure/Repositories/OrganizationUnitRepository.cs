using Microsoft.EntityFrameworkCore;
using OrganizationAssetManagement.Application.Common.Interfaces;
using OrganizationAssetManagement.Domain.Entities;
using OrganizationAssetManagement.Infrastructure.Persistence;

namespace OrganizationAssetManagement.Infrastructure.Repositories;

public class OrganizationUnitRepository : IOrganizationUnitRepository
{
    private readonly ApplicationDbContext _context;

    public OrganizationUnitRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<OrganizationUnit?> GetByIdAsync(Guid id)
    {
        return await _context.OrganizationUnits
            .Include(x => x.ParentOrganizationUnit)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<OrganizationUnit>> GetAllAsync()
    {
        return await _context.OrganizationUnits
            .Include(x => x.ParentOrganizationUnit)
            .ToListAsync();
    }

    public async Task AddAsync(OrganizationUnit organizationUnit)
    {
        await _context.OrganizationUnits.AddAsync(organizationUnit);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(OrganizationUnit organizationUnit)
    {
        _context.OrganizationUnits.Update(organizationUnit);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(OrganizationUnit organizationUnit)
    {
        _context.OrganizationUnits.Remove(organizationUnit);
        await _context.SaveChangesAsync();
    }
}