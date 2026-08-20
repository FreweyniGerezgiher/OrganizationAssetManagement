using MediatR;
using OrganizationAssetManagement.Application.Common.Interfaces;
using OrganizationAssetManagement.Application.Common.Models;

namespace OrganizationAssetManagement.Application.Features.Assets.Queries.GetAssetById;

public class GetAssetByIdQueryHandler
    : IRequestHandler<GetAssetByIdQuery, AssetDto?>
{
    private readonly IAssetRepository _assetRepository;

    public GetAssetByIdQueryHandler(IAssetRepository assetRepository)
    {
        _assetRepository = assetRepository;
    }

    public async Task<AssetDto?> Handle(
        GetAssetByIdQuery request,
        CancellationToken cancellationToken)
    {
        var asset = await _assetRepository.GetByIdAsync(request.Id);

        if (asset == null)
        {
            return null;
        }

        return new AssetDto
        {
            Id = asset.Id,
            Name = asset.Name,
            AssetTag = asset.AssetTag,
            SerialNumber = asset.SerialNumber,
            Description = asset.Description,
            Status = asset.Status.ToString(),
            OrganizationUnitId = asset.OrganizationUnitId,
            OrganizationUnitName = asset.OrganizationUnit?.Name
        };
    }
}