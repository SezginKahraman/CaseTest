using Application.Features.Draws.Commands.Create;
using Application.Features.Draws.Commands.Delete;
using Application.Features.Draws.Commands.PickAllDraws;
using Application.Features.Draws.Commands.Update;
using Application.Features.Draws.Queries.GetById;
using Application.Features.Draws.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DrawsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateDrawCommand createDrawCommand)
    {
        CreatedDrawResponse response = await Mediator.Send(createDrawCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateDrawCommand updateDrawCommand)
    {
        UpdatedDrawResponse response = await Mediator.Send(updateDrawCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedDrawResponse response = await Mediator.Send(new DeleteDrawCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdDrawResponse response = await Mediator.Send(new GetByIdDrawQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListDrawQuery getListDrawQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListDrawListItemDto> response = await Mediator.Send(getListDrawQuery);
        return Ok(response);
    }
}