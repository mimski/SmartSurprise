using System.Collections.Generic;

namespace SmartSurprise.Web.Models;

public class PaginationModel<T>
{
    public IEnumerable<T> Items { get; set; }
    public int PageIndex { get; set; }
    public int TotalPages { get; set; }
    public bool HasPreviousPage => PageIndex > 1;
    public bool HasNextPage => PageIndex < TotalPages;
}
