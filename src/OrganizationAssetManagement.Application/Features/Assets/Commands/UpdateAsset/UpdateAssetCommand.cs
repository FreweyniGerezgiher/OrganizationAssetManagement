using MediatR;
using OrganizationAssetManagement.Application.Common.Models;
using OrganizationAssetManagement.Domain.Enums;

namespace OrganizationAssetManagement.Application.Features.Assets.Commands.UpdateAsset;

public class UpdateAssetCommand : IRequest<AssetDto>
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string AssetTag { get; set; } = string.Empty;

    public string SerialNumber { get; set; } = string.Empty;

    public string? Description { get; set; }

    public AssetStatus? Status { get; set; }

    public Guid? OrganizationUnitId { get; set; }
}