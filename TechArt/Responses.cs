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
    public bool Status { get; set; }

    public BaseResponse<T> CreateResponse(string message, bool status, T data)
    {
        return new BaseResponse<T>
        {
            Message = message,
            Status = status,
            Data = data
        };
    }
}