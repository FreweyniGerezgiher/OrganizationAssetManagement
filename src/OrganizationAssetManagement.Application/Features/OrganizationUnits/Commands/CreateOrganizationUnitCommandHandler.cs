using MediatR;
using OrganizationAssetManagement.Application.Common.Interfaces;
using OrganizationAssetManagement.Application.Common.Models;
using OrganizationAssetManagement.Domain.Entities;

namespace OrganizationAssetManagement.Application.Features.OrganizationUnits.Commands;

public class CreateOrganizationUnitCommandHandler
    : IRequestHandler<CreateOrganizationUnitCommand, OrganizationUnitDto>
{
    private readonly IOrganizationUnitRepository _repository;

    public CreateOrganizationUnitCommandHandler(
        IOrganizationUnitRepository repository)
    {
        _repository = repository;
    }

    public async Task<OrganizationUnitDto> Handle(
        CreateOrganizationUnitCommand command,
        CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(command.Name))
        {
            throw new Exception("Organization unit name is required.");
        }

        OrganizationUnit? parent = null;

        if (command.ParentOrganizationUnitId.HasValue)
        {
            parent = await _repository.GetByIdAsync(
                command.ParentOrganizationUnitId.Value);

            if (parent == null)
            {
                throw new Exception("Parent organization unit was not found.");
            }
        }

        var organizationUnit = new OrganizationUnit
        {
            Name = command.Name,
            Description = command.Description,
            ParentOrganizationUnitId = command.ParentOrganizationUnitId
        };

        await _repository.AddAsync(organizationUnit);

        return new OrganizationUnitDto
        {
            Id = organizationUnit.Id,
            Name = organizationUnit.Name,
            Description = organizationUnit.Description,
            ParentOrganizationUnitId =
                organizationUnit.ParentOrganizationUnitId,
            ParentOrganizationUnitName = parent?.Name
        };
    }
}