using MediatR;
using OrganizationAssetManagement.Application.Common.DTOs;

namespace OrganizationAssetManagement.Application.Features.Documents.Queries.GetAssetDocuments;

public class GetAssetDocumentsQuery
    : IRequest<List<DocumentDto>>
{
    public Guid AssetId { get; set; }

    public GetAssetDocumentsQuery(Guid assetId)
    {
        AssetId = assetId;
    }
}