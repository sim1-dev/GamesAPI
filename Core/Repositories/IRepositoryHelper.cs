using GamesAPI.Core.Models;

namespace StandardizedFilters.Core.Services.Request;

public interface IRepositoryHelper<T> {
    public IQueryable<T> ApplyFilters(IQueryable<T> query, RequestFilter[]? filters);

    public IQueryable<T> ApplyOrder(IQueryable<T> query, RequestOrder? order);
}