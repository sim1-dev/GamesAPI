using GamesAPI.Core.Models;

namespace GamesAPI.Core.Services;

public interface IService<T, TCreateDto, TUpdateDto> {
    public Task<IEnumerable<T>> Get(RequestFilter[]? filters = null, RequestOrder? order = null);
    public Task<T?> Find(int id);
    public Task<T> Create(TCreateDto TPlatformDto);
    public Task<T?> Update(int id, TUpdateDto updateDto);
    public Task<bool> Delete(int id);
}