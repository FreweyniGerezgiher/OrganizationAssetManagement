using MediatR;

namespace OrganizationAssetManagement.Application.Features.Assets.Commands.DeleteAsset;

public class DeleteAssetCommand : IRequest<bool>
{
    public Guid Id { get; set; }

    public DeleteAssetCommand(Guid id)
    {
        Id = id;
    }
}