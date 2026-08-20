using MediatR;
using OrganizationAssetManagement.Application.Common.DTOs;


namespace OrganizationAssetManagement.Application.Features.Assets.Commands.ReturnAsset;

public class ReturnAssetCommand : IRequest<AssetAssignmentDto>
{
    public Guid AssetId { get; set; }
}