using MediatR;
using OrganizationAssetManagement.Application.Common.Models;

namespace OrganizationAssetManagement.Application.Features.OrganizationUnits.Commands;

public class UpdateOrganizationUnitCommand : IRequest<OrganizationUnitDto>
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string? Description { get; set; }

    public Guid? ParentOrganizationUnitId { get; set; }
}