using MediatR;
using OrganizationAssetManagement.Application.Common.Interfaces;
using OrganizationAssetManagement.Application.Common.Models;
using OrganizationAssetManagement.Domain.Entities;
using OrganizationAssetManagement.Domain.Enums;

namespace OrganizationAssetManagement.Application.Features.Assets.Commands.CreateAsset;

public class CreateAssetCommandHandler : IRequestHandler<CreateAssetCommand, AssetDto>
{
    private readonly IAssetRepository _assetRepository;

    public CreateAssetCommandHandler(IAssetRepository assetRepository)
    {
        _assetRepository = assetRepository;
    }

    public async Task<AssetDto> Handle(
        CreateAssetCommand request,
        CancellationToken cancellationToken)
    {
        var asset = new Asset
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            AssetTag = request.AssetTag,
            SerialNumber = request.SerialNumber,
            Description = request.Description,
            Status = AssetStatus.Available,
            CreatedAt = DateTime.UtcNow
        };

        await _assetRepository.AddAsync(asset);

        return new AssetDto
        {
            Id = asset.Id,
            Name = asset.Name,
            AssetTag = asset.AssetTag,
            SerialNumber = asset.SerialNumber,
            Description = asset.Description,
            Status = asset.Status.ToString()
        };
    }
}