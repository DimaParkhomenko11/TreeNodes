namespace TreeNode.Api.ExceptionRecords.Responses;

public class ExceptionRecordsResponse
{
    public int Id { get; set; }
    public string EventId { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
}