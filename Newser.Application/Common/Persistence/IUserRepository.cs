using Newser.Domain.Entities;

namespace Newser.Application.Common.Persistence;

public interface IUserRepository
{
    void Add(User user);
    User? GetByEmail(string email);
    User? GetById(Guid id);
}