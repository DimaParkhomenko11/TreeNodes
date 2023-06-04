using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace TreeNode.Api.Nodes.Requests;

public class CreateNodeRequest
{
    public int ParentNodeId  { get; set; }
    public string TreeName { get; set; } = null!;
    public string NodeName   { get; set; } = null!;
}