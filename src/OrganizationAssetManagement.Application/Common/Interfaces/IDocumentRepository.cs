using OrganizationAssetManagement.Domain.Entities;

namespace OrganizationAssetManagement.Application.Common.Interfaces;

public interface IDocumentRepository
{
    Task<Document?> GetByIdAsync(Guid id);

    Task<List<Document>> GetAllAsync();

    Task AddAsync(Document document);
}