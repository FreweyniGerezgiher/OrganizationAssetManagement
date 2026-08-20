using MediatR;
using OrganizationAssetManagement.Application.Common.DTOs;
using OrganizationAssetManagement.Application.Common.Models;

namespace OrganizationAssetManagement.Application.Features.Assets.Commands.AssignAsset;

public class AssignAssetCommand : IRequest<AssetAssignmentDto>
{
    public Guid AssetId { get; set; }

    public Guid UserId { get; set; }
}