namespace TreeNode.Application.Exceptions;

public class ErrorDetails
{
    public string Type { get; set; }
    public string Id { get; set; }
    public Data Data { get; set; }
}
public class Data
{
    public string Message { get; set; }
}