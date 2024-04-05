using System.ComponentModel;

namespace Application.DTOs
{
    public class PaginationDto
    {
        public int PageIndex { get; set; } = 0;
        public int PageSize { get; set; } = 0;
    }
}
