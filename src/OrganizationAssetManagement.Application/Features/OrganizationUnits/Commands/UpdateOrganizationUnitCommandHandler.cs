using MediatR;
using OrganizationAssetManagement.Application.Common.Interfaces;
using OrganizationAssetManagement.Application.Common.Models;

namespace OrganizationAssetManagement.Application.Features.OrganizationUnits.Commands;

public class UpdateOrganizationUnitCommandHandler
    : IRequestHandler<UpdateOrganizationUnitCommand, OrganizationUnitDto>
{
    private readonly IOrganizationUnitRepository _repository;

    public UpdateOrganizationUnitCommandHandler(
        IOrganizationUnitRepository repository)
    {
        _repository = repository;
    }

    public async Task<OrganizationUnitDto> Handle(
        UpdateOrganizationUnitCommand command,
        CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(command.Name))
        {
            throw new Exception("Organization unit name is required.");
        }

        var organizationUnit =
            await _repository.GetByIdAsync(command.Id);

        if (organizationUnit == null)
        {
            throw new Exception("Organization unit was not found.");
        }

        if (command.ParentOrganizationUnitId == command.Id)
        {
            throw new Exception(
                "An organization unit cannot be its own parent.");
        }

        OrganizationUnitDto result;

        string? parentName = null;

        if (command.ParentOrganizationUnitId.HasValue)
        {
            var parent = await _repository.GetByIdAsync(
                command.ParentOrganizationUnitId.Value);

            if (parent == null)
            {
                throw new Exception(
                    "Parent organization unit was not found.");
            }

            parentName = parent.Name;

            var currentParent = parent;

            while (currentParent.ParentOrganizationUnitId.HasValue)
            {
                if (currentParent.ParentOrganizationUnitId == command.Id)
                {
                    throw new Exception(
                        "This parent would create a circular hierarchy.");
                }

                currentParent = await _repository.GetByIdAsync(
                    currentParent.ParentOrganizationUnitId.Value);

                if (currentParent == null)
                {
                    break;
                }
            }
        }

        organizationUnit.Name = command.Name;
        organizationUnit.Description = command.Description;
        organizationUnit.ParentOrganizationUnitId =
            command.ParentOrganizationUnitId;

        await _repository.UpdateAsync(organizationUnit);

        result = new OrganizationUnitDto
        {
            Id = organizationUnit.Id,
            Name = organizationUnit.Name,
            Description = organizationUnit.Description,
            ParentOrganizationUnitId =
                organizationUnit.ParentOrganizationUnitId,
            ParentOrganizationUnitName = parentName
        };

        return result;
    }
}