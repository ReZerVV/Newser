namespace Newser.Application.Commands.Post.GetPosts;

public record GetPostsResponse(
    string Id,
    string Title,
    string Description,
    string Date
);