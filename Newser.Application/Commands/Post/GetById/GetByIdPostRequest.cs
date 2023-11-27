using MediatR;

namespace Newser.Application.Commands.Post.GetById;

public record GetByIdPostRequest(
    string Id
) : IRequest<GetByIdPostResponse>;