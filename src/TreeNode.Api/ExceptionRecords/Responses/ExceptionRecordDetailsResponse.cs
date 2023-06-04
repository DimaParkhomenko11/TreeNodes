namespace TreeNode.Api.ExceptionRecords.Responses;

public class ExceptionRecordDetailsResponse
{
    public int Id { get; set; }
    public string EventId { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
    public string Text { get; set; } = null!;
}