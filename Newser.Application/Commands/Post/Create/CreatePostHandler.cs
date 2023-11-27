using MediatR;
using Newser.Application.Common.Persistence;
using Newser.Application.Common.Services;
using Newser.Domain.Entities;

namespace Newser.Application.Commands.Post.Create;

public class CreatePostHandler : IRequestHandler<CreatePostRequest, CreatePostResponse>
{
    private readonly IUserRepository _userRepository;
    private readonly IPostRepository _postRepository;
    private readonly IDateTimeProvider _dateTimeProvider;

    public CreatePostHandler(IPostRepository postRepository, IUserRepository userRepository, IDateTimeProvider dateTimeProvider)
    {
        _postRepository = postRepository;
        _userRepository = userRepository;
        _dateTimeProvider = dateTimeProvider;
    }

    public Task<CreatePostResponse> Handle(CreatePostRequest request, CancellationToken cancellationToken)
    {
        if (_userRepository.GetById(request.AuthorId) is not User user)
        {
            throw new ApplicationException("User with given id not found");
        }

        var post = new Domain.Entities.Post
        {
            Id = Guid.NewGuid(),
            AuthorId = user.Id,
            DateCreated = _dateTimeProvider.UtcNow,
            Title = request.Title,
            Description = request.Description,
        };
        
        _postRepository.Add(post);

        return Task.FromResult(
            new CreatePostResponse(
                Id: post.Id.ToString()
            )
        );
    }
}
