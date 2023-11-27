using FluentResults;
using MediatR;
using Newser.Application.Common.Authorization;
using Newser.Application.Common.Exceptions;
using Newser.Application.Common.Persistence;
using Newser.Domain.Entities;

namespace Newser.Application.Commands.Authorization.Login;

public class LoginHandler : IRequestHandler<LoginRequest, LoginResponse>
{
    private readonly IUserRepository _userRepository;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public LoginHandler(IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator)
    {
        _userRepository = userRepository;
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public Task<LoginResponse> Handle(LoginRequest request, CancellationToken cancellationToken)
    {
        if (_userRepository.GetByEmail(request.Email) is not User user)
        {
            throw new UserNotFoundException();
        }

        if (user.Password != request.Password)
        {
            throw new InvalidPasswordException();
        }

        string token = _jwtTokenGenerator.TokenGenerate(user);

        return Task.FromResult(
            new LoginResponse(
                Id: user.Id.ToString(),
                Name: user.Username,
                Email: user.Email,
                Token: token
            )
        );
    }
}