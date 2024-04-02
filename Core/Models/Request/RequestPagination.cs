namespace GamesAPI.Core.Models;

public class RequestPagination {
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = int.MaxValue;
}
