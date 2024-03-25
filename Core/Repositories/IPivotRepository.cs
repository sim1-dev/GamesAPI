public interface IPivotRepository<T> {
    Task Create(T entity);
    Task Delete(T entity);
}