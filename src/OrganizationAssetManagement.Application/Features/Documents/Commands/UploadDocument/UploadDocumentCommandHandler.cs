using MediatR;
using OrganizationAssetManagement.Application.Common.DTOs;
using OrganizationAssetManagement.Application.Common.Interfaces;
using OrganizationAssetManagement.Domain.Entities;

namespace OrganizationAssetManagement.Application.Features.Documents.Commands.UploadDocument;

public class UploadDocumentCommandHandler
    : IRequestHandler<UploadDocumentCommand, DocumentDto>
{
    private readonly IAssetRepository _assetRepository;
    private readonly IDocumentRepository _documentRepository;
    private readonly IFileService _fileService;

    public UploadDocumentCommandHandler(
        IAssetRepository assetRepository,
        IDocumentRepository documentRepository,
        IFileService fileService)
    {
        _assetRepository = assetRepository;
        _documentRepository = documentRepository;
        _fileService = fileService;
    }

    public async Task<DocumentDto> Handle(
        UploadDocumentCommand request,
        CancellationToken cancellationToken)
    {
        var asset = await _assetRepository.GetByIdAsync(
            request.AssetId);

        if (asset == null)
        {
            throw new Exception("Asset was not found.");
        }

        var filePath = await _fileService.SaveFileAsync(
            request.FileStream,
            request.FileName);

        var document = new Document
        {
            Id = Guid.NewGuid(),
            FileName = request.FileName,
            FilePath = filePath,
            ContentType = request.ContentType,
            AssetId = request.AssetId,
            CreatedAt = DateTime.UtcNow
        };

        await _documentRepository.AddAsync(document);

        return new DocumentDto
        {
            Id = document.Id,
            FileName = document.FileName,
            FilePath = document.FilePath,
            ContentType = document.ContentType,
            AssetId = document.AssetId,
            CreatedAt = document.CreatedAt
        };
    }
}