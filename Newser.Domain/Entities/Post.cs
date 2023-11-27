namespace Newser.Domain.Entities;

public class Post
{
    public Guid Id { get; set; }
    public Guid AuthorId { get; set; }
    public DateTime? DateCreated { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
}