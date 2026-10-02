using MediatR;
using OrganizationAssetManagement.Application.Common.DTOs;

namespace OrganizationAssetManagement.Application.Features.Users.Queries.GetUserById;

public class GetUserByIdQuery : IRequest<UserDto?>
{
    public Guid Id { get; set; }
}