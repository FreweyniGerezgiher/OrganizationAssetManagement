using MediatR;
using OrganizationAssetManagement.Application.Common.DTOs;
using OrganizationAssetManagement.Application.Common.Models;

namespace OrganizationAssetManagement.Application.Features.Assets.Queries.GetAssetHistory;

public class GetAssetHistoryQuery : IRequest<List<AssetHistoryDto>>
{
    public Guid AssetId { get; set; }

    public GetAssetHistoryQuery(Guid assetId)
    {
        AssetId = assetId;
    }
}