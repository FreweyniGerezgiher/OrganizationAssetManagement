using MediatR;
using OrganizationAssetManagement.Application.Common.Interfaces;

namespace OrganizationAssetManagement.Application.Features.Assets.Commands.DeleteAsset;

public class DeleteAssetCommandHandler
    : IRequestHandler<DeleteAssetCommand, bool>
{
    private readonly IAssetRepository _assetRepository;

    public DeleteAssetCommandHandler(IAssetRepository assetRepository)
    {
        _assetRepository = assetRepository;
    }

    public async Task<bool> Handle(
        DeleteAssetCommand request,
        CancellationToken cancellationToken)
    {
        var asset = await _assetRepository.GetByIdAsync(request.Id);

        if (asset == null)
        {
            return false;
        }

        await _assetRepository.DeleteAsync(asset);

        return true;
    }
}