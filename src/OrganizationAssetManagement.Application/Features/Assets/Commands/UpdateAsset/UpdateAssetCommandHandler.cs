using MediatR;
using OrganizationAssetManagement.Application.Common.Interfaces;
using OrganizationAssetManagement.Application.Common.Models;

namespace OrganizationAssetManagement.Application.Features.Assets.Commands.UpdateAsset;

public class UpdateAssetCommandHandler
    : IRequestHandler<UpdateAssetCommand, AssetDto>
{
    private readonly IAssetRepository _assetRepository;
    private readonly IOrganizationUnitRepository _organizationUnitRepository;

    public UpdateAssetCommandHandler(
        IAssetRepository assetRepository,
        IOrganizationUnitRepository organizationUnitRepository)
    {
        _assetRepository = assetRepository;
        _organizationUnitRepository = organizationUnitRepository;
    }

    public async Task<AssetDto> Handle(
        UpdateAssetCommand command,
        CancellationToken cancellationToken)
    {
        var asset = await _assetRepository.GetByIdAsync(command.Id);

        if (asset == null)
        {
            throw new Exception("Asset was not found.");
        }

        string? organizationUnitName = null;

        if (command.OrganizationUnitId.HasValue)
        {
            var organizationUnit =
                await _organizationUnitRepository.GetByIdAsync(
                    command.OrganizationUnitId.Value);

            if (organizationUnit == null)
            {
                throw new Exception("Organization unit not found.");
            }

            organizationUnitName = organizationUnit.Name;
        }

        asset.Name = command.Name;
        asset.AssetTag = command.AssetTag;
        asset.SerialNumber = command.SerialNumber;
        asset.Description = command.Description;
        asset.OrganizationUnitId = command.OrganizationUnitId;

        if (command.Status.HasValue)
        {
            asset.Status = command.Status.Value;
        }

        await _assetRepository.UpdateAsync(asset);

        return new AssetDto
        {
            Id = asset.Id,
            Name = asset.Name,
            AssetTag = asset.AssetTag,
            SerialNumber = asset.SerialNumber,
            Description = asset.Description,
            Status = asset.Status.ToString(),
            OrganizationUnitId = asset.OrganizationUnitId,
            OrganizationUnitName = organizationUnitName
        };
    }
}