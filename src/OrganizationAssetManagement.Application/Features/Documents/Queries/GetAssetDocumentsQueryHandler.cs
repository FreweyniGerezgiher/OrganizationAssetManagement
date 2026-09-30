using MediatR;
using OrganizationAssetManagement.Application.Common.DTOs;
using OrganizationAssetManagement.Application.Common.Interfaces;

namespace OrganizationAssetManagement.Application.Features.Documents.Queries.GetAssetDocuments;

public class GetAssetDocumentsQueryHandler
    : IRequestHandler<GetAssetDocumentsQuery, List<DocumentDto>>
{
    private readonly IDocumentRepository _documentRepository;

    public GetAssetDocumentsQueryHandler(
        IDocumentRepository documentRepository)
    {
        _documentRepository = documentRepository;
    }

    public async Task<List<DocumentDto>> Handle(
        GetAssetDocumentsQuery request,
        CancellationToken cancellationToken)
    {
        var documents =
            await _documentRepository.GetByAssetIdAsync(
                request.AssetId);

        return documents.Select(x => new DocumentDto
        {
            Id = x.Id,
            FileName = x.FileName,
            FilePath = x.FilePath,
            ContentType = x.ContentType,
            AssetId = x.AssetId,
            CreatedAt = x.CreatedAt
        }).ToList();
    }
}