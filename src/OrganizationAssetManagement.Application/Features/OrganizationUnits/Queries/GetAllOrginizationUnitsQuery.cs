using MediatR;
using OrganizationAssetManagement.Application.Common.Models;

namespace OrganizationAssetManagement.Application.Features.OrganizationUnits.Queries;

public class GetAllOrganizationUnitsQuery
    : IRequest<List<OrganizationUnitDto>>
{
}