using FluentValidation;
using TreeNode.Api.Trees.Filters;

namespace TreeNode.Api.Trees.Validators;

public class TreesFilterValidator : AbstractValidator<TreesFilter>
{
    private const int MaxValue = 366;
    private const int MinTakeValue = 0;
    private const int MinSkipValue = -1;

    public TreesFilterValidator()
    {
        RuleFor(x => x.Take)
            .LessThan(MaxValue)
            .GreaterThan(MinTakeValue);


        RuleFor(x => x.Skip)
            .GreaterThan(MinSkipValue);
    }
}