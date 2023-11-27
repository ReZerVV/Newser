using Newser.Domain.Entities;

namespace Newser.Application.Common.Persistence;

public interface IPostRepository
{
    void Add(Post post);
    void Update(Post post);
    void Remove(Post post);
    Post? GetById(Guid id);
    IEnumerable<Post> GetWithOrderByDate();
}