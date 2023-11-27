using MediatR;

namespace Newser.Application.Commands.Authorization.Register;

public record RegisterRequest(
    string Name,
    string Email,
    string Password
) : IRequest<RegisterResponse>;