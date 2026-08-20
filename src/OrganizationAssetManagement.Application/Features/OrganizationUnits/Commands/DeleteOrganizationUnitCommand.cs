using MediatR;

namespace OrganizationAssetManagement.Application.Features.OrganizationUnits.Commands;

public class DeleteOrganizationUnitCommand : IRequest<bool>
{
    public Guid Id { get; set; }

    public DeleteOrganizationUnitCommand(Guid id)
    {
        Id = id;
    }
}