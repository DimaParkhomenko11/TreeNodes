using FluentValidation;
using TreeNode.Api.ExceptionRecords.Filters;

namespace TreeNode.Api.ExceptionRecords.Validators;

public class ExceptionRecordsFilterValidator : AbstractValidator<ExceptionRecordsFilter>
{
    private const int MaxSearchValue = 1000;
    private const int MaxTakeValue = 366;
    private const int MinTakeValue = 0;
    private const int MinSkipValue = -1;
    
    public ExceptionRecordsFilterValidator()
    {
        RuleFor(x => x.Take)
            .LessThan(MaxTakeValue)
            .GreaterThan(MinTakeValue);
        
        RuleFor(x => x.Skip)
            .GreaterThan(MinSkipValue);

        RuleFor(x => x.Search)
            .MaximumLength(MaxSearchValue);
    }
}