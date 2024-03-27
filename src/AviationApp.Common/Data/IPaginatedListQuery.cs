namespace AviationApp.Common.Data;

public interface IPaginatedListQuery
{
    int PageNumber { get; set; }
    int PageSize { get; set; }
}