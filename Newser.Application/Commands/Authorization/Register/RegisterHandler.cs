using MediatR;
using Newser.Application.Common.Authorization;
using Newser.Application.Common.Exceptions;
using Newser.Application.Common.Persistence;
using Newser.Domain.Entities;

namespace Newser.Application.Commands.Authorization.Register;

public class RegisterHandler : IRequestHandler<RegisterRequest, RegisterResponse>
{
    private readonly IUserRepository _userRepository;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public RegisterHandler(IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator)
    {
        _userRepository = userRepository;
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public Task<RegisterResponse> Handle(RegisterRequest request, CancellationToken cancellationToken)
    {
        if (_userRepository.GetByEmail(request.Email) is not null)
        {
            throw new UserEmailConflictException();
        }

        User user = new User
        {
            Id = Guid.NewGuid(),
            Username = request.Name,
            Email = request.Email,
            Password = request.Password,
        };

        _userRepository.Add(user);

        string token = _jwtTokenGenerator.TokenGenerate(user);

        return Task.FromResult(
            new RegisterResponse(
                Id: user.Id.ToString(),
                Name: user.Username,
                Email: user.Email,
                Token: token
            )
        );
    }
}
