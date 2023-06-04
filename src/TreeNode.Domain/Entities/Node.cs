namespace TreeNode.Domain.Entities;

public class Node
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int? ParentNodeId { get; set; }

    public virtual Node? ParentNode { get; set; }

    public virtual ICollection<Node>? Children { get; set; } = new HashSet<Node>();
}