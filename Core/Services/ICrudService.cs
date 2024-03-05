namespace GamesAPI.Core.Services;

public interface ICrudService<T, TDto, TCreateDto, TUpdateDto> {
    public Task<List<T>> GetAll();
    public Task<T?> Find(int id);
    public Task<T> Create(TCreateDto TPlatformDto);
    public Task<T?> Update(int id, TUpdateDto updateDto);
    public Task<T?> Delete(int id);
}