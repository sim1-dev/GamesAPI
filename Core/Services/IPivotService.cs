namespace GamesAPI.Core.Services;

public interface IPivotService<T> {
    public Task<T> Create(int firstTableId, int secondTableId);
}