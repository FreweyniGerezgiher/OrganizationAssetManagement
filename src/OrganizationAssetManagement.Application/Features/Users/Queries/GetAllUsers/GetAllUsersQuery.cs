using MediatR;
using OrganizationAssetManagement.Application.Common.DTOs;

namespace OrganizationAssetManagement.Application.Features.Users.Queries.GetAllUsers;

public class GetAllUsersQuery : IRequest<List<UserDto>>
{
}