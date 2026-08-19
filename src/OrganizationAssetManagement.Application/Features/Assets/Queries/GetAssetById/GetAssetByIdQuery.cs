using MediatR;
using OrganizationAssetManagement.Application.Common.Models;

namespace OrganizationAssetManagement.Application.Features.Assets.Queries.GetAssetById;

public class GetAssetByIdQuery : IRequest<AssetDto?>
{
    public Guid Id { get; set; }
}