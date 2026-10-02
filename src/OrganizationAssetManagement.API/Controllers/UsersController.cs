using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrganizationAssetManagement.Application.Features.Users.Queries.GetAllUsers;
using OrganizationAssetManagement.Application.Features.Users.Queries.GetUserById;

namespace OrganizationAssetManagement.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class UsersController : ControllerBase
{
    private readonly IMediator _mediator;

    public UsersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _mediator.Send(new GetAllUsersQuery());

        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _mediator.Send(
            new GetUserByIdQuery
            {
                Id = id
            });

        if (result == null)
        {
            return NotFound();
        }

        return Ok(result);
    }
}