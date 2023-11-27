using Microsoft.EntityFrameworkCore;
using Newser.Application.Common.Persistence;
using Newser.Domain.Entities;

namespace Newser.Infrastructure.Persistence;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _appDbContext;

    public UserRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public void Add(User user)
    {
        _appDbContext.Users.Add(user);
        _appDbContext.SaveChanges();
    }

    public User? GetByEmail(string email)
    {
        return _appDbContext.Users
            .FirstOrDefault(user => user.Email == email);
    }

    public User? GetById(Guid id)
    {
        return _appDbContext.Users
            .FirstOrDefault(user => user.Id == id);
    }
}
