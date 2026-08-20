using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrganizationAssetManagement.Application.Features.OrganizationUnits.Commands;
using OrganizationAssetManagement.Application.Features.OrganizationUnits.Queries;


namespace OrganizationAssetManagement.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class OrganizationUnitsController : ControllerBase
{
    private readonly IMediator _mediator;

    public OrganizationUnitsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create(
        CreateOrganizationUnitCommand command)
    {
        var result = await _mediator.Send(command);

        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _mediator.Send(
            new GetAllOrganizationUnitsQuery());

        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _mediator.Send(
            new GetOrganizationUnitByIdQuery(id));

        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(
        Guid id,
        UpdateOrganizationUnitCommand command)
    {
        command.Id = id;

        var result = await _mediator.Send(command);

        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _mediator.Send(
            new DeleteOrganizationUnitCommand(id));

        return Ok(new
        {
            message = "Organization unit deleted successfully."
        });
    }
}