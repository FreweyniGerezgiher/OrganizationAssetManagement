using OrganizationAssetManagement.Domain.Entities;

namespace OrganizationAssetManagement.Application.Common.Interfaces;

public interface IDocumentRepository
{
    Task<Document?> GetByIdAsync(Guid id);

    Task<List<Document>> GetAllAsync();

    Task<List<Document>> GetByAssetIdAsync(Guid assetId);

    Task AddAsync(Document document);

    Task DeleteAsync(Document document);
}