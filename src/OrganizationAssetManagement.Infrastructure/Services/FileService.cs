using OrganizationAssetManagement.Application.Common.Interfaces;

namespace OrganizationAssetManagement.Infrastructure.Services;

public class FileService : IFileService
{
    private readonly string _uploadFolder;

    public FileService()
    {
        _uploadFolder = Path.Combine(
            Directory.GetCurrentDirectory(),
            "wwwroot",
            "uploads");

        if (!Directory.Exists(_uploadFolder))
        {
            Directory.CreateDirectory(_uploadFolder);
        }
    }

    public async Task<string> SaveFileAsync(
        Stream fileStream,
        string fileName)
    {
        var extension = Path.GetExtension(fileName);

        var uniqueFileName =
            $"{Guid.NewGuid()}{extension}";

        var fullPath = Path.Combine(
            _uploadFolder,
            uniqueFileName);

        using var outputStream = new FileStream(
            fullPath,
            FileMode.Create);

        await fileStream.CopyToAsync(outputStream);

        return Path.Combine(
                "uploads",
                uniqueFileName)
            .Replace("\\", "/");
    }

    public void DeleteFile(string filePath)
    {
        var fullPath = Path.Combine(
            Directory.GetCurrentDirectory(),
            "wwwroot",
            filePath);

        if (File.Exists(fullPath))
        {
            File.Delete(fullPath);
        }
    }
}