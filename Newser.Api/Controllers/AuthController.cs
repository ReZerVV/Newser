using MediatR;
using Microsoft.AspNetCore.Mvc;
using Newser.Application.Commands.Authorization.Login;
using Newser.Application.Commands.Authorization.Register;

namespace Newser.Api.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly IMediator _mediator;

    public AuthController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("register")]
    public IActionResult Register(RegisterRequest request)
    {
        return Ok(_mediator.Send(request));
    }

    [HttpPost("login")]
    public IActionResult Login(LoginRequest request)
    {
        return Ok(_mediator.Send(request));
    }
}