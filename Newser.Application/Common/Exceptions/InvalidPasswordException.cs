namespace Newser.Application.Common.Exceptions;

public class InvalidPasswordException : ApplicationException
{
    public InvalidPasswordException()
        : base("Invalid password")
    {
    }
}