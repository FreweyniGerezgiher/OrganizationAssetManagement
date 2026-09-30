namespace OrganizationAssetManagement.Application.Common.Interfaces;

public interface IFileService
{
    Task<string> SaveFileAsync(
        Stream fileStream,
        string fileName);

    void DeleteFile(string filePath);
}