using FluentValidation;
using TreeNode.Api.Trees.Requests;

namespace TreeNode.Api.Trees.Validators;

public class CreateTreeRequestValidator : AbstractValidator<CreateTreeRequest>
{
    private const int NameMaximumLength = 1000;
    private const int NameMinimumLength = 3;
    
    public CreateTreeRequestValidator()
    {
        RuleFor(x => x.Name)
            .MaximumLength(NameMaximumLength)
            .MinimumLength(NameMinimumLength)
            .NotEmpty();
    }
} 