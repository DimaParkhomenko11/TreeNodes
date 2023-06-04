namespace TreeNode.Application.ExceptionRecords.Results;

public class ExceptionRecordsResult
{
    public int Id { get; set; }
    public string EventId { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
}