namespace TechArt;

public class PaginatedResponse<T> where T : class
{
    public List<T> Items { get; set; }
    public int TotalRecords { get; set; }
    public int CurrentPage { get; set; }
    public int PageSize { get; set; }

    public bool HasData() => Items is { Count: > 0 };
}

public class BaseResponse<T>
{
    public string Message { get; set; }
    public T Data { get; set; }
    public bool IsSuccessful { get; set; }

    public BaseResponse<T> CreateResponse(string message, bool isSuccessful, T data)
    {
        return new BaseResponse<T>
        {
            Message = message,
            IsSuccessful = isSuccessful,
            Data = data
        };
    }
}

public static class QueryableExtensions
{
    public static async Task<PaginatedResult<T>> ToPaginatedListAsync<T>(this IQueryable<T> source, int pageNumber, int pageSize) where T : class
    {
        Throw.Exception.IfNull(source, nameof(source));
        pageNumber = pageNumber == 0 ? 1 : pageNumber;
        pageSize = pageSize == 0 ? 10 : pageSize;
        long count = await source.LongCountAsync();
        pageNumber = pageNumber <= 0 ? 1 : pageNumber;
        List<T> items = await source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
        return PaginatedResult<T>.Success(items, count, pageNumber, pageSize);
    }
}