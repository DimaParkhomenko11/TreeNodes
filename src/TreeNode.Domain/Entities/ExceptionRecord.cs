namespace TreeNode.Domain.Entities;

public class ExceptionRecord
{
    public int Id { get; set; }
    
    public Guid EventId { get; set; }

    public DateTime CreatedAt{ get; set; }
    
    public string? Text { get; set; }
}