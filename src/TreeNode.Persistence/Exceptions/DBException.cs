namespace TreeNode.Persistence.Exceptions;

public class DBException : Exception
{
    public DBException(): base()
    { }
    
    public DBException(string message): base(message)
    { }
}