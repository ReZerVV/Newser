namespace Newser.Application.Commands.Authorization.Login;

public record LoginResponse(
    string Id,
    string Name,
    string Email,
    string Token
);