public interface IRepository<T> {
    Task<IEnumerable<T>> GetAll();
    Task<T?> Find(int id);
    Task Create(T entity);
    Task Update(T entity);
    Task Delete(T entity);
}