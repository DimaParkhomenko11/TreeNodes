using FluentValidation;

namespace TreeNode.Api.Trees.Requests;

public class CreateTreeRequest
{
    public string Name { get; set; } = null!;
}