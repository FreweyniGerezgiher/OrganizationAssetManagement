using MediatR;
using OrganizationAssetManagement.Application.Common.DTOs;

namespace OrganizationAssetManagement.Application.Features.Documents.Commands.UploadDocument;

public class UploadDocumentCommand : IRequest<DocumentDto>
{
    public Guid AssetId { get; set; }

    public string FileName { get; set; } = string.Empty;

    public string? ContentType { get; set; }

    public Stream FileStream { get; set; } = Stream.Null;
}