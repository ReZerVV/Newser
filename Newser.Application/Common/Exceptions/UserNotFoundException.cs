namespace Newser.Application.Common.Exceptions;

public class UserNotFoundException : ApplicationException
{
    public UserNotFoundException()
        : base("User with given email not found")
    {
    }
}