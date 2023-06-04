using FluentValidation;
using TreeNode.Api.Nodes.Requests;

namespace TreeNode.Api.Nodes.Validators;

public class UpdateNodeRequestValidator : AbstractValidator<UpdateNodeRequest>
{
    private const int NameMaximumLength = 1000;
    private const int NameMinimumLength = 3;
    
    public UpdateNodeRequestValidator()
    {
        RuleFor(x => x.Name)
            .MaximumLength(NameMaximumLength)
            .MinimumLength(NameMinimumLength)
            .NotEmpty();
    }
}