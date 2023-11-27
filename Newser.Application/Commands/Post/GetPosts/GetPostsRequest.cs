using MediatR;

namespace Newser.Application.Commands.Post.GetPosts;

public record GetPostsRequest(

) : IRequest<IEnumerable<GetPostsResponse>>;