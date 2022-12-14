using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Helpers;

public class BasePaginatedResponse<T>
{
    public bool IsSuccess { get; set; }
    public T Data { get; set; }
    public int Page { get; set; }
    public int PageSize { get; set; }
    public int TotalPages { get; set; }
    public int TotalItems { get; set; }
    public string Message { get; set; }
}
