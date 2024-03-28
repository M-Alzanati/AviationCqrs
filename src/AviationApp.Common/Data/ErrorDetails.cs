using Newtonsoft.Json;

namespace AviationApp.Common.Data;

public class ErrorDetails
{
    public int StatusCode { get; set; }
    
    public string? Message { get; set; }
    
    public string? Detailed { get; set; }

    public override string ToString()
    {
        return JsonConvert.SerializeObject(this);
    }
}