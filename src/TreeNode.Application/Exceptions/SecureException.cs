namespace TreeNode.Application.Exceptions;

public class SecureException : Exception
{
    public SecureException()
    { }
    
    public SecureException(string message):base(message)
    { }
}