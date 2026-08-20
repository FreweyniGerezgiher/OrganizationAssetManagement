using MediatR;
using OrganizationAssetManagement.Application.Common.Models;

namespace OrganizationAssetManagement.Application.Features.OrganizationUnits.Commands;

public class CreateOrganizationUnitCommand : IRequest<OrganizationUnitDto>
{
    public string Name { get; set; } = string.Empty;

    public string? Description { get; set; }

    public Guid? ParentOrganizationUnitId { get; set; }
}