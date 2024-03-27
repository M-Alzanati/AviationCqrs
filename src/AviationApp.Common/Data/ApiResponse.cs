namespace AviationApp.Common.Data;

public class ApiResponse<T>
{
    public bool Success { get; set; }
    
    public string Message { get; set; }
    
    public T Data { get; set; }
    
    public DateTime Timestamp { get; } = DateTime.UtcNow;

    public ApiResponse(T data, bool success = true, string message = "")
    {
        Data = data;
        Success = success;
        Message = message;
    }
    
    public static ApiResponse<T> Create(T data, bool success = true, string message = "")
    {
        return new ApiResponse<T>(data, success, message);
    }
}