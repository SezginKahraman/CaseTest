using Application.Features.Pickers.Commands.Create;
using Application.Features.Pickers.Commands.Delete;
using Application.Features.Pickers.Commands.Update;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PickersController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreatePickerCommand createPickerCommand)
        {
            CreatedPickerResponse response = await Mediator.Send(createPickerCommand);

            return Created(uri: "", response);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdatePickerCommand updatePickerCommand)
        {
            UpdatedPickerResponse response = await Mediator.Send(updatePickerCommand);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            DeletedPickerResponse response = await Mediator.Send(new DeletePickerCommand { Id = id });

            return Ok(response);
        }

        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetById([FromRoute] int id)
        //{
        //    GetByIdPickerResponse response = await Mediator.Send(new GetByIdPickerQuery { Id = id });
        //    return Ok(response);
        //}

        //[HttpGet]
        //public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        //{
        //    GetListPickerQuery getListPickerQuery = new() { PageRequest = pageRequest };
        //    GetListResponse<GetListPickerListItemDto> response = await Mediator.Send(getListPickerQuery);
        //    return Ok(response);
        //}
    }
}
