using MediatR;
using OrganizationAssetManagement.Application.Common.Interfaces;
using OrganizationAssetManagement.Application.Common.Models;

namespace OrganizationAssetManagement.Application.Features.OrganizationUnits.Queries;

public class GetAllOrganizationUnitsQueryHandler
    : IRequestHandler<GetAllOrganizationUnitsQuery, List<OrganizationUnitDto>>
{
    private readonly IOrganizationUnitRepository _repository;

    public GetAllOrganizationUnitsQueryHandler(
        IOrganizationUnitRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<OrganizationUnitDto>> Handle(
        GetAllOrganizationUnitsQuery request,
        CancellationToken cancellationToken)
    {
        var organizationUnits = await _repository.GetAllAsync();

        return organizationUnits.Select(x => new OrganizationUnitDto
        {
            Id = x.Id,
            Name = x.Name,
            Description = x.Description,
            ParentOrganizationUnitId =
                x.ParentOrganizationUnitId,
            ParentOrganizationUnitName =
                x.ParentOrganizationUnit?.Name
        }).ToList();
    }
}