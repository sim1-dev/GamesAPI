using Microsoft.AspNetCore.StaticFiles;

namespace GamesAPI.Core.Services;
public class FileService: IFileService {
    const string UPLOAD_PATH = "Uploads";
    private readonly string _uploadsFolderPath;

    private readonly IContentTypeProvider _contentTypeProvider;
    public FileService(IContentTypeProvider contentTypeProvider, string path = UPLOAD_PATH) {
        this._contentTypeProvider = contentTypeProvider;
        this._uploadsFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "Public/" + UPLOAD_PATH);

        if (!Directory.Exists(_uploadsFolderPath))
            Directory.CreateDirectory(_uploadsFolderPath);
    }

    // returns the unique file name
    public async Task<string> Upload(IFormFile file) {
        if (file == null || file.Length == 0)
            throw new ArgumentException("File is null or empty");

        string uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
        string filePath = Path.Combine(_uploadsFolderPath, uniqueFileName);

        using (var stream = new FileStream(filePath, FileMode.Create))
            await file.CopyToAsync(stream);

        return uniqueFileName;
    }

    // returns an object which can be returned from controller with File(fileContents.Bytes, fileContents.MimeType, fileContents.FileName)
    public FileContents Download(string fileName) {
        string filePath = Path.Combine(_uploadsFolderPath, fileName);

        if (!File.Exists(filePath))
            throw new FileNotFoundException("File not found", filePath);

        string mimeType;
        if (!_contentTypeProvider.TryGetContentType(fileName, out mimeType!))
            mimeType = "application/octet-stream";

        FileContents fileContents = new FileContents(fileName, filePath, mimeType);

        return fileContents;
    }
}
