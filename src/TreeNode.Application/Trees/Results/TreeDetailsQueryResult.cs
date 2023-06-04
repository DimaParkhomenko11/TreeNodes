namespace TreeNode.Application.Trees.Results;

public class TreeDetailsQueryResult
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public ICollection<TreeDetailsQueryResult>? Children { get; set; }
}