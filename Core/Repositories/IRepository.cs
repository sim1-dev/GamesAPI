using GamesAPI.Core.Models;

public interface IRepository<T> {
    Task<IEnumerable<T>> Get(RequestFilter[]? filters = null, RequestOrder? order = null);
    Task<T?> Find(int id);
    Task Create(T entity);
    Task Update(T entity);
    Task Delete(T entity);
}