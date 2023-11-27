namespace Newser.Application.Commands.Post.Edit;

public record EditPostResponse(
    string Id,
    string Title,
    string Description,
    string Date
);