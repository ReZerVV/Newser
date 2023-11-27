using MediatR;

namespace Newser.Application.Commands.Authorization.Login;

public record LoginRequest(
    string Email,
    string Password
) : IRequest<LoginResponse>;