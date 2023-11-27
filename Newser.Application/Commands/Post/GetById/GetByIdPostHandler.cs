using MediatR;
using Newser.Application.Common.Persistence;

namespace Newser.Application.Commands.Post.GetById;

public class GetByIdPostHandler : IRequestHandler<GetByIdPostRequest, GetByIdPostResponse>
{
    private readonly IPostRepository _postRepository;

    public GetByIdPostHandler(IPostRepository postRepository)
    {
        _postRepository = postRepository;
    }

    public Task<GetByIdPostResponse> Handle(GetByIdPostRequest request, CancellationToken cancellationToken)
    {
        if (_postRepository.GetById(Guid.Parse(request.Id)) is not Domain.Entities.Post post)
        {
            throw new ApplicationException("Post with given id not found");
        }

        return Task.FromResult(
            new GetByIdPostResponse(
                Id: post.Id.ToString(),
                Title: post.Title,
                Description: post.Description,
                Date: post.DateCreated?.ToString()
            )
        );
    }
}
