namespace Newser.Application.Commands.Authorization.Register;

public record RegisterResponse(
    string Id,
    string Name,
    string Email,
    string Token
);