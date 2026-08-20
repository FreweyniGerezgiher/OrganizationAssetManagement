using MediatR;
using OrganizationAssetManagement.Application.Common.DTOs;

namespace OrganizationAssetManagement.Application.Features.Authentication.Commands;

public class LoginCommand : IRequest<LoginResponse>
{
    public LoginRequest Request { get; set; }

    public LoginCommand(LoginRequest request)
    {
        Request = request;
    }
}