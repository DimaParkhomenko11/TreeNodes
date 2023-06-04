using TreeNode.Application.Interfaces;

namespace TreeNode.Application.Contracts.Pagination;

public class PaginatedResult<T> : IPaginatedResult<T>
{
    public IEnumerable<T> Items { get; set; }

    public int Count { get; set; }
    
    public int Skip { get; set; }
}