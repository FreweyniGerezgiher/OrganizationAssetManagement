using MediatR;
using OrganizationAssetManagement.Application.Common.Interfaces;
using OrganizationAssetManagement.Application.Common.Models;

namespace OrganizationAssetManagement.Application.Features.OrganizationUnits.Queries;

public class GetOrganizationUnitByIdQueryHandler
    : IRequestHandler<GetOrganizationUnitByIdQuery, OrganizationUnitDto>
{
    private readonly IOrganizationUnitRepository _repository;

    public GetOrganizationUnitByIdQueryHandler(
        IOrganizationUnitRepository repository)
    {
        _repository = repository;
    }

    public async Task<OrganizationUnitDto> Handle(
        GetOrganizationUnitByIdQuery request,
        CancellationToken cancellationToken)
    {
        var organizationUnit =
            await _repository.GetByIdAsync(request.Id);

        if (organizationUnit == null)
        {
            throw new Exception("Organization unit was not found.");
        }

        return new OrganizationUnitDto
        {
            Id = organizationUnit.Id,
            Name = organizationUnit.Name,
            Description = organizationUnit.Description,
            ParentOrganizationUnitId =
                organizationUnit.ParentOrganizationUnitId,
            ParentOrganizationUnitName =
                organizationUnit.ParentOrganizationUnit?.Name
        };
    }
}