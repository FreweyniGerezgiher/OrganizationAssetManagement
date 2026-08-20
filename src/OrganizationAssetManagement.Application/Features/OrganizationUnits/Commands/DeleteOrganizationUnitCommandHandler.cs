using MediatR;
using OrganizationAssetManagement.Application.Common.Interfaces;

namespace OrganizationAssetManagement.Application.Features.OrganizationUnits.Commands;

public class DeleteOrganizationUnitCommandHandler
    : IRequestHandler<DeleteOrganizationUnitCommand, bool>
{
    private readonly IOrganizationUnitRepository _repository;

    public DeleteOrganizationUnitCommandHandler(
        IOrganizationUnitRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(
        DeleteOrganizationUnitCommand command,
        CancellationToken cancellationToken)
    {
        var organizationUnit =
            await _repository.GetByIdAsync(command.Id);

        if (organizationUnit == null)
        {
            throw new Exception("Organization unit was not found.");
        }

        var allUnits = await _repository.GetAllAsync();

        var hasChildren = allUnits.Any(x =>
            x.ParentOrganizationUnitId == command.Id);

        if (hasChildren)
        {
            throw new Exception(
                "Cannot delete an organization unit that has children.");
        }

        await _repository.DeleteAsync(organizationUnit);

        return true;
    }
}