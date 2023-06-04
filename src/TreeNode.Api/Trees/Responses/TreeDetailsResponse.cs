namespace TreeNode.Api.Trees.Responses;

public class TreeDetailsResponse
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public ICollection<TreeDetailsResponse>? Children { get; set; }
}