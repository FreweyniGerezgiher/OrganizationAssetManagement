using MediatR;
using OrganizationAssetManagement.Application.Common.Interfaces;
using OrganizationAssetManagement.Domain.Entities;
using OrganizationAssetManagement.Domain.Enums;

namespace OrganizationAssetManagement.Application.Features.Authentication.Commands;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, Guid>
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordService _passwordService;

    public RegisterCommandHandler(
        IUserRepository userRepository,
        IPasswordService passwordService)
    {
        _userRepository = userRepository;
        _passwordService = passwordService;
    }

    public async Task<Guid> Handle(
        RegisterCommand command,
        CancellationToken cancellationToken)
    {
        var existingUser = await _userRepository
            .GetByEmailAsync(command.Request.Email);

        if (existingUser != null)
        {
            throw new Exception("A user with this email already exists.");
        }

        var user = new User
        {
            FirstName = command.Request.FirstName,
            LastName = command.Request.LastName,
            Email = command.Request.Email,
            PasswordHash = _passwordService.HashPassword(
                command.Request.Password),
            Role = UserRole.Viewer,
            OrganizationUnitId = command.Request.OrganizationUnitId
        };

        await _userRepository.AddAsync(user);

        return user.Id;
    }
}