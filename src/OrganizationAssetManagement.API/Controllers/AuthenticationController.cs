using MediatR;
using Microsoft.AspNetCore.Mvc;
using OrganizationAssetManagement.Application.Common.DTOs;
using OrganizationAssetManagement.Application.Features.Authentication.Commands;


namespace OrganizationAssetManagement.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthenticationController : ControllerBase
{
    private readonly IMediator _mediator;

    public AuthenticationController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        var userId = await _mediator.Send(
            new RegisterCommand(request));

        return Ok(new
        {
            UserId = userId,
            Message = "User registered successfully."
        });
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var result = await _mediator.Send(
            new LoginCommand(request));

        return Ok(result);
    }
}