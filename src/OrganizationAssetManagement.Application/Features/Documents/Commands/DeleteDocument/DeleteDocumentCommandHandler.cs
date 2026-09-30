using MediatR;
using OrganizationAssetManagement.Application.Common.Interfaces;

namespace OrganizationAssetManagement.Application.Features.Documents.Commands.DeleteDocument;

public class DeleteDocumentCommandHandler
    : IRequestHandler<DeleteDocumentCommand>
{
    private readonly IDocumentRepository _documentRepository;
    private readonly IFileService _fileService;

    public DeleteDocumentCommandHandler(
        IDocumentRepository documentRepository,
        IFileService fileService)
    {
        _documentRepository = documentRepository;
        _fileService = fileService;
    }

    public async Task Handle(
        DeleteDocumentCommand request,
        CancellationToken cancellationToken)
    {
        var document =
            await _documentRepository.GetByIdAsync(request.Id);

        if (document == null)
        {
            throw new Exception("Document was not found.");
        }

        _fileService.DeleteFile(document.FilePath);

        await _documentRepository.DeleteAsync(document);
    }
}