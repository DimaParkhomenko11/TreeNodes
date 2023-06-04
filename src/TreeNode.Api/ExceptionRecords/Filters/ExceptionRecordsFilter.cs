namespace TreeNode.Api.ExceptionRecords.Filters;

public class ExceptionRecordsFilter
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

    /// <summary>
    ///     The time from which you want to filter the data
    /// </summary>
    public DateTime? From { get; set; }
    
    /// <summary>
    ///     The time to which you want to filter the data
    /// </summary>
    public DateTime? To { get; set; }
    
    /// <summary>
    ///     Search
    /// </summary>
    public string? Search { get; set; }
}