using MediatR;

namespace OrganizationAssetManagement.Application.Features.Documents.Commands.DeleteDocument;

public class DeleteDocumentCommand : IRequest
{
    public Guid Id { get; set; }

    public DeleteDocumentCommand(Guid id)
    {
        Id = id;
    }
}