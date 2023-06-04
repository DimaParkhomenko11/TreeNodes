namespace TreeNode.Application.ExceptionRecords.Results;

public class ExceptionRecordDetailsResult
{
    public int Id { get; set; }
    public string EventId { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
    public string Text { get; set; } = null!;
}