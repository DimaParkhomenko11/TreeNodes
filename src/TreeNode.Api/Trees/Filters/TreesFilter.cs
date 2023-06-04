namespace TreeNode.Api.Trees.Filters;

public class TreesFilter
{
    private const int TakeDefaultValue = 10;
    
    /// <summary>
    ///     Skip a certain number of objects
    /// </summary>
    public int? Skip { get; set; }
        
    /// <summary>
    ///     Take a certain number of objects
    /// </summary>
    public int Take { get; set; } = TakeDefaultValue;
}