using MediatR;
using Newser.Application.Common.Persistence;

namespace Newser.Application.Commands.Post.GetPosts;

public class GetPostsHandler : IRequestHandler<GetPostsRequest, IEnumerable<GetPostsResponse>>
{
    private readonly IPostRepository _postRepository;

    public GetPostsHandler(IPostRepository postRepository)
    {
        _postRepository = postRepository;
    }

    public Task<IEnumerable<GetPostsResponse>> Handle(GetPostsRequest request, CancellationToken cancellationToken)
    {
        return Task.FromResult(
            _postRepository
                .GetWithOrderByDate()
                .Select(post => new GetPostsResponse(
                    Id: post.Id.ToString(),
                    Title: post.Title,
                    Description: post.Description,
                    Date: post.DateCreated.ToString()
                ))
        );
    }
}
