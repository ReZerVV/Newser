using MediatR;
using Newser.Application.Common.Persistence;

namespace Newser.Application.Commands.Post.Delete;

public class DeletePostHandler : IRequestHandler<DeletePostRequest>
{
    private readonly IPostRepository _postRepository;

    public DeletePostHandler(IPostRepository postRepository)
    {
        _postRepository = postRepository;
    }

    public Task Handle(DeletePostRequest request, CancellationToken cancellationToken)
    {
        if (_postRepository.GetById(Guid.Parse(request.Id)) is not Domain.Entities.Post post)
        {
            throw new ApplicationException("Post with given id not found");
        }

        _postRepository.Remove(post);

        return Task.CompletedTask;
    }
}
