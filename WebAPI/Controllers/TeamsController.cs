using Application.Features.Teams.Commands.CleanTeamsGroups;
using Application.Features.Teams.Commands.Create;
using Application.Features.Teams.Commands.Delete;
using Application.Features.Teams.Commands.Update;
using Application.Features.Teams.Queries.GetAllSeparatedByGroupId;
using Application.Features.Teams.Queries.GetById;
using Application.Features.Teams.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TeamsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateTeamCommand createTeamCommand)
    {
        CreatedTeamResponse response = await Mediator.Send(createTeamCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateTeamCommand updateTeamCommand)
    {
        UpdatedTeamResponse response = await Mediator.Send(updateTeamCommand);

        return Ok(response);
    }
    [HttpPut("ungroup")]
    public async Task<IActionResult> UngroupTeams([FromBody] CleanTeamsGroupsCommand cleanTeamsGroupsCommand)
    {
        CleanTeamsGroupsResponse response = await Mediator.Send(cleanTeamsGroupsCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedTeamResponse response = await Mediator.Send(new DeleteTeamCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdTeamResponse response = await Mediator.Send(new GetByIdTeamQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListTeamQuery getListTeamQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListTeamListItemDto> response = await Mediator.Send(getListTeamQuery);
        return Ok(response);
    }

    [HttpGet("getDistinctGroupped")]
    public async Task<IActionResult> GetAllDistinct([FromQuery] GetDistinctGrouppedQuery getAllSeparatedByGroupIdQuery)
    {
        GetListResponse<GetAllSeparatedByGroupIdDto> response = await Mediator.Send(getAllSeparatedByGroupIdQuery);
        return Ok(response);
    }
}