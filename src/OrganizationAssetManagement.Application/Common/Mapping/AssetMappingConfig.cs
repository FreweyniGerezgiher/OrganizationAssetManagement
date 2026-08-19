using Mapster;
using OrganizationAssetManagement.Application.Common.Models;
using OrganizationAssetManagement.Domain.Entities;

namespace OrganizationAssetManagement.Application.Common.Mapping;

public static class AssetMappingConfig
{
    public static void RegisterMappings()
    {
        TypeAdapterConfig<Asset, AssetDto>
            .NewConfig()
            .Map(dest => dest.Status, src => src.Status.ToString());
    }
}