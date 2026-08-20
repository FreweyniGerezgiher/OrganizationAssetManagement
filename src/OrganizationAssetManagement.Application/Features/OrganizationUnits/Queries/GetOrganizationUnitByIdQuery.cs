using MediatR;
using OrganizationAssetManagement.Application.Common.Models;

namespace OrganizationAssetManagement.Application.Features.OrganizationUnits.Queries;

public class GetOrganizationUnitByIdQuery : IRequest<OrganizationUnitDto>
{
    public Guid Id { get; set; }

    public GetOrganizationUnitByIdQuery(Guid id)
    {
        Id = id;
    }
}