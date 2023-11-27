using MediatR;

namespace Newser.Application.Commands.Post.Edit;

public record EditPostRequest(
    string Id,
    string Title,
    string Description
) : IRequest<EditPostResponse>;