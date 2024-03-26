namespace GamesAPI.Core.Services;

public interface IFileService {
    public Task<string> Upload(IFormFile file);
    public FileContents Download(string fileName);
}