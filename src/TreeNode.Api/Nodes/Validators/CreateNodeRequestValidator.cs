using FluentValidation;
using TreeNode.Api.Nodes.Requests;

namespace TreeNode.Api.Nodes.Validators;

public class CreateNodeRequestValidator : AbstractValidator<CreateNodeRequest>
{
    private const int NameMaximumLength = 1000;
    private const int NameMinimumLength = 3;
    
    public CreateNodeRequestValidator()
    {
        RuleFor(x => x.NodeName)
            .MaximumLength(NameMaximumLength)
            .MinimumLength(NameMinimumLength)
            .NotEmpty();
        
        RuleFor(x => x.ParentNodeId)
            .NotEmpty();
        
        RuleFor(x => x.TreeName)
            .NotEmpty();
    }
}