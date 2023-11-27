namespace Newser.Application.Common.Exceptions;

public class UserEmailConflictException : ApplicationException
{
    public UserEmailConflictException()
        : base("User with given email already exists")
    {
    }
}