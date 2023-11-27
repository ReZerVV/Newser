using Newser.Application.Common.Persistence;
using Newser.Domain.Entities;

namespace Newser.Infrastructure.Persistence;

public class PostRepository : IPostRepository
{
    private readonly AppDbContext _appDbContext;

    public PostRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public void Add(Post post)
    {
        _appDbContext.Posts.Add(post);
        _appDbContext.SaveChanges();
    }

    public Post? GetById(Guid id)
    {
        return _appDbContext.Posts
            .FirstOrDefault(post => post.Id == id);
    }

    public IEnumerable<Post> GetWithOrderByDate()
    {
        return _appDbContext.Posts
            .OrderByDescending(post => post.DateCreated);
    }

    public void Remove(Post post)
    {
        _appDbContext.Remove(post);
        _appDbContext.SaveChanges();
    }

    public void Update(Post post)
    {
        _appDbContext.Update(post);
        _appDbContext.SaveChanges();
    }
}