namespace Newser.Application.Commands.Post.GetById;

public record GetByIdPostResponse(
    string Id,
    string Title,
    string Description,
    string Date
);