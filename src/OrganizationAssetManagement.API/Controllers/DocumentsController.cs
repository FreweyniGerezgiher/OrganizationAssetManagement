using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrganizationAssetManagement.API.Models;
using OrganizationAssetManagement.Application.Features.Documents.Commands.DeleteDocument;
using OrganizationAssetManagement.Application.Features.Documents.Commands.UploadDocument;
using OrganizationAssetManagement.Application.Features.Documents.Queries.GetAssetDocuments;


namespace OrganizationAssetManagement.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class DocumentsController : ControllerBase
{
    private readonly IMediator _mediator;

    public DocumentsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("asset/{assetId}")]
    public async Task<IActionResult> Upload(
        Guid assetId,
        [FromForm] UploadDocumentRequest request)
    {
        if (request.File == null ||
            request.File.Length == 0)
        {
            return BadRequest("File is required.");
        }

        var allowedExtensions = new[]
        {
            ".pdf",
            ".jpg",
            ".jpeg",
            ".png",
            ".doc",
            ".docx"
        };

        var extension =
            Path.GetExtension(request.File.FileName)
                .ToLowerInvariant();

        if (!allowedExtensions.Contains(extension))
        {
            return BadRequest(
                "Unsupported file type.");
        }

        const long maxFileSize = 10 * 1024 * 1024;

        if (request.File.Length > maxFileSize)
        {
            return BadRequest(
                "File size cannot exceed 10 MB.");
        }

        await using var stream =
            request.File.OpenReadStream();

        var command = new UploadDocumentCommand
        {
            AssetId = assetId,
            FileName = request.File.FileName,
            ContentType = request.File.ContentType,
            FileStream = stream
        };

        var result = await _mediator.Send(command);

        return Ok(result);
    }

    [HttpGet("asset/{assetId}")]
    public async Task<IActionResult> GetByAsset(
        Guid assetId)
    {
        var result = await _mediator.Send(
            new GetAssetDocumentsQuery(assetId));

        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _mediator.Send(
            new DeleteDocumentCommand(id));

        return Ok(new
        {
            message = "Document deleted successfully."
        });
    }
}