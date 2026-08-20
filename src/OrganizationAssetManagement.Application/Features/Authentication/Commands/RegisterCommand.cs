using MediatR;
using OrganizationAssetManagement.Application.Common.DTOs;

namespace OrganizationAssetManagement.Application.Features.Authentication.Commands;

public class RegisterCommand : IRequest<Guid>
{
    public RegisterRequest Request { get; set; }

    public RegisterCommand(RegisterRequest request)
    {
        Request = request;
    }
}