using MediatR;
using Newser.Application.Common.Persistence;
using Newser.Application.Common.Services;

namespace Newser.Application.Commands.Post.Edit;

public class EditPostHandler : IRequestHandler<EditPostRequest, EditPostResponse>
{
    private readonly IPostRepository _postRepository;
    private readonly IDateTimeProvider _dateTimeProvider;

    public EditPostHandler(IPostRepository postRepository, IDateTimeProvider dateTimeProvider)
    {
        _postRepository = postRepository;
        _dateTimeProvider = dateTimeProvider;
    }

    public Task<EditPostResponse> Handle(EditPostRequest request, CancellationToken cancellationToken)
    {
        if (_postRepository.GetById(Guid.Parse(request.Id)) is not Domain.Entities.Post post)
        {
            throw new ApplicationException("Post with given id not found");
        }

        post.Title = request.Title;
        post.Description = request.Description;
        post.DateCreated = _dateTimeProvider.UtcNow;

        _postRepository.Update(post);

        return Task.FromResult(
            new EditPostResponse(
                Id: post.Id.ToString(),
                Title: post.Title,
                Description: post.Description,
                Date: post.DateCreated.ToString()
            )
        );
    }
}
