using Application.Features.GroupTeams.Commands.Create;
using Application.Features.GroupTeams.Commands.Delete;
using Application.Features.GroupTeams.Commands.Update;
using Application.Features.GroupTeams.Commands.Create;
using Application.Features.GroupTeams.Commands.Delete;
using Application.Features.GroupTeams.Commands.Update;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupTeamsController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateGroupTeamCommand createGroupTeamCommand)
        {
            CreatedGroupTeamResponse response = await Mediator.Send(createGroupTeamCommand);

            return Created(uri: "", response);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateGroupTeamCommand updateGroupTeamCommand)
        {
            UpdatedGroupTeamResponse response = await Mediator.Send(updateGroupTeamCommand);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            DeletedGroupTeamResponse response = await Mediator.Send(new DeleteGroupTeamCommand { Id = id });

            return Ok(response);
        }

        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetById([FromRoute] int id)
        //{
        //    GetByIdGroupTeamResponse response = await Mediator.Send(new GetByIdGroupTeamQuery { Id = id });
        //    return Ok(response);
        //}

        //[HttpGet]
        //public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        //{
        //    GetListGroupTeamQuery getListGroupTeamQuery = new() { PageRequest = pageRequest };
        //    GetListResponse<GetListGroupTeamListItemDto> response = await Mediator.Send(getListGroupTeamQuery);
        //    return Ok(response);
        //}
    }
}
