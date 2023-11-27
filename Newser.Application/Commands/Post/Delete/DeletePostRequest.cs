using MediatR;

namespace Newser.Application.Commands.Post.Delete;

public record DeletePostRequest(
    string Id
) : IRequest;