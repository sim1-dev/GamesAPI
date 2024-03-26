namespace GamesAPI.Core.Services;

public interface IExportService<T> {
    FileContents Export(List<T> data, string fileName = "export");
}