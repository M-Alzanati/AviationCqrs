namespace AviationApp.Common.Clients.AviationStack;

public abstract class BaseAviationStackResponse<T>
{
    public Pagination? Pagination { set; get; }
    
    public abstract IEnumerable<T>? Data { get; set; }
}

public class Pagination
{
    public int Limit { get; set; }
    public int Offset { get; set; }
    public int Count { get; set; }
    public int Total { get; set; }
}