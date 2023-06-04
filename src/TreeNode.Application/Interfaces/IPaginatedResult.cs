namespace TreeNode.Application.Interfaces;

public interface IPaginatedResult<T>
{
    IEnumerable<T> Items { get; set; }
    int Count { get; set; }
    int Skip { get; set; }
}