namespace OrganizationAssetManagement.API.Models;

public class UploadDocumentRequest
{
    public IFormFile File { get; set; } = null!;
}