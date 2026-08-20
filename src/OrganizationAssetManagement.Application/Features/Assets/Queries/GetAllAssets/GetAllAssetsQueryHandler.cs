using MediatR;
using OrganizationAssetManagement.Application.Common.Interfaces;
using OrganizationAssetManagement.Application.Common.Models;

namespace OrganizationAssetManagement.Application.Features.Assets.Queries.GetAllAssets;

public class GetAllAssetsQueryHandler : IRequestHandler<GetAllAssetsQuery, List<AssetDto>>
{
    private readonly IAssetRepository _assetRepository;

    public GetAllAssetsQueryHandler(IAssetRepository assetRepository)
    {
        _assetRepository = assetRepository;
    }

    public async Task<List<AssetDto>> Handle(
        GetAllAssetsQuery request,
        CancellationToken cancellationToken)
    {
        var assets = await _assetRepository.GetAllAsync();

        return assets.Select(x => new AssetDto
        {
            Id = x.Id,
            Name = x.Name,
            AssetTag = x.AssetTag,
            SerialNumber = x.SerialNumber,
            Description = x.Description,
            Status = x.Status.ToString(),
            OrganizationUnitId = x.OrganizationUnitId,
            OrganizationUnitName = x.OrganizationUnit?.Name
        }).ToList();
    }
}