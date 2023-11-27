using MediatR;

namespace Newser.Application.Commands.Post.Create;

public record CreatePostRequest(
    Guid AuthorId,
    string Title,
    string Description
) : IRequest<CreatePostResponse>;