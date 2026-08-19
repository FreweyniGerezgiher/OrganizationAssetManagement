using MediatR;
using OrganizationAssetManagement.Application.Common.Models;

namespace OrganizationAssetManagement.Application.Features.Assets.Commands.CreateAsset;

public class CreateAssetCommand : IRequest<AssetDto>
{
    public string Name { get; set; } = string.Empty;

    public string AssetTag { get; set; } = string.Empty;

    public string SerialNumber { get; set; } = string.Empty;

    public string? Description { get; set; }
}