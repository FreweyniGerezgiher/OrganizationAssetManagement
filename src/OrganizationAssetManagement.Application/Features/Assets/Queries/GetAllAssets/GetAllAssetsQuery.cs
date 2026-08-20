using MediatR;
using OrganizationAssetManagement.Application.Common.Models;

namespace OrganizationAssetManagement.Application.Features.Assets.Queries.GetAllAssets;

public class GetAllAssetsQuery : IRequest<List<AssetDto>>
{
}