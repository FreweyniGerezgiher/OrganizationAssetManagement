using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrganizationAssetManagement.Application.Features.Assets.Commands.CreateAsset;
using OrganizationAssetManagement.Application.Features.Assets.Commands.UpdateAsset;
using OrganizationAssetManagement.Application.Features.Assets.Commands.DeleteAsset;
using OrganizationAssetManagement.Application.Features.Assets.Queries.GetAllAssets;
using OrganizationAssetManagement.Application.Features.Assets.Queries.GetAssetById;
using OrganizationAssetManagement.Application.Features.Assets.Commands.AssignAsset;
using OrganizationAssetManagement.Application.Features.Assets.Commands.ReturnAsset;
using OrganizationAssetManagement.Application.Features.Assets.Queries.GetAssetHistory;

namespace OrganizationAssetManagement.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class AssetsController : ControllerBase
{
    private readonly IMediator _mediator;

    public AssetsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateAssetCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _mediator.Send(new GetAllAssetsQuery());
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _mediator.Send(new GetAssetByIdQuery { Id = id });
        if (result == null)
        {
            return NotFound();
        }

        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, UpdateAssetCommand command)
    {
        command.Id = id;
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _mediator.Send(new DeleteAssetCommand(id));
        return Ok(new { message = "Asset deleted successfully." });
    }

    [HttpPost("{assetId}/assign")]
    public async Task<IActionResult> Assign(
    Guid assetId,
    AssignAssetCommand command)
    {
        command.AssetId = assetId;

        var result = await _mediator.Send(command);

        return Ok(result);
    }

    [HttpPost("{assetId}/return")]
    public async Task<IActionResult> Return(Guid assetId)
    {
        var result = await _mediator.Send(
            new ReturnAssetCommand
            {
                AssetId = assetId
            });

        return Ok(result);
    }

    [HttpGet("{assetId}/history")]
    public async Task<IActionResult> GetHistory(Guid assetId)
    {
        var result = await _mediator.Send(
            new GetAssetHistoryQuery(assetId));

        return Ok(result);
    }
}