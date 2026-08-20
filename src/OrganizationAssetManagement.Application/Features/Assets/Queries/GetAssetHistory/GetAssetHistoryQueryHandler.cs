using MediatR;
using OrganizationAssetManagement.Application.Common.DTOs;
using OrganizationAssetManagement.Application.Common.Interfaces;

namespace OrganizationAssetManagement.Application.Features.Assets.Queries.GetAssetHistory;

public class GetAssetHistoryQueryHandler
    : IRequestHandler<GetAssetHistoryQuery, List<AssetHistoryDto>>
{
    private readonly IAssetHistoryRepository _historyRepository;

    public GetAssetHistoryQueryHandler(
        IAssetHistoryRepository historyRepository)
    {
        _historyRepository = historyRepository;
    }

    public async Task<List<AssetHistoryDto>> Handle(
        GetAssetHistoryQuery request,
        CancellationToken cancellationToken)
    {
        var history = await _historyRepository
            .GetByAssetIdAsync(request.AssetId);

        return history.Select(x => new AssetHistoryDto
        {
            Id = x.Id,
            AssetId = x.AssetId,
            Action = x.Action,
            Description = x.Description,
            ActionDate = x.ActionDate
        }).ToList();
    }
}