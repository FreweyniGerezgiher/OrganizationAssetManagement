using Microsoft.EntityFrameworkCore;
using OrganizationAssetManagement.Application.Common.Interfaces;
using OrganizationAssetManagement.Domain.Entities;
using OrganizationAssetManagement.Infrastructure.Persistence;

namespace OrganizationAssetManagement.Infrastructure.Repositories;

public class DocumentRepository : IDocumentRepository
{
    private readonly ApplicationDbContext _context;

    public DocumentRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Document?> GetByIdAsync(Guid id)
    {
        return await _context.Documents
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<Document>> GetAllAsync()
    {
        return await _context.Documents.ToListAsync();
    }

    public async Task AddAsync(Document document)
    {
        await _context.Documents.AddAsync(document);
        await _context.SaveChangesAsync();
    }
}