using System.Security.Claims;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newser.Application.Commands.Post.Create;
using Newser.Application.Commands.Post.Delete;
using Newser.Application.Commands.Post.Edit;
using Newser.Application.Commands.Post.GetById;
using Newser.Application.Commands.Post.GetPosts;
using Newser.Contracts;

namespace Newser.Api.Controllers;

[ApiController]
[Route("api/posts")]
public class PostController : ControllerBase
{
    private readonly IMediator _mediator;

    public PostController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [Authorize]
    [HttpPost]
    public IActionResult Create(PostCreate request)
    {
        return Ok(_mediator.Send(
            new CreatePostRequest(
                AuthorId: Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value),
                Title: request.Title,
                Description: request.Description
            )
        ));
    }

    [Authorize]
    [HttpDelete("{id:guid}")]
    public IActionResult Delete([FromRoute] Guid id)
    {
        return Ok(_mediator.Send(new DeletePostRequest(
            Id: id.ToString()
        )));
    }

    [Authorize]
    [HttpPut("{id:guid}")]
    public IActionResult Edit([FromRoute] Guid id, [FromBody] PostEdit request)
    {
        return Ok(_mediator.Send(new EditPostRequest(
            Id: id.ToString(),
            Title: request.Title,
            Description: request.Description
        )));
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetById([FromRoute] Guid id)
    {
        return Ok(_mediator.Send(new GetByIdPostRequest(
            Id: id.ToString()
        )));
    }

    [HttpGet]
    public IActionResult GetPosts()
    {
        return Ok(_mediator.Send(new GetPostsRequest()));
    }
}