using Application.BussinessLogic.Items.Command.Add;
using Application.BussinessLogic.Items.Command.Delete;
using Application.BussinessLogic.Items.Command.Update;
using Application.BussinessLogic.Items.DTOs;
using Application.BussinessLogic.Items.Query.GetAll;
using Application.BussinessLogic.Items.Query.GetById;
using Application.DTOs;
using Application.DTOs.Response;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LuftBornCodeTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly IMediator mediator;

        public ItemsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(typeof(ResponseDto<List<ItemDto>>), 200)]
        public async Task<IActionResult> GetAllAsync([FromQuery] PaginationDto getAll)
        {
            var result = await mediator.Send(new GetAllQuery { PaginationdData = getAll });
            return Ok(result);
        }

        [HttpGet("{Id}")]
        [ProducesResponseType(typeof(ResponseDto<ItemDto>), 200)]
        public async Task<ActionResult> GetByIdAsync([FromRoute] GetByIdQuery request)
        {
            var result = await mediator.Send(request);
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(typeof(ResponseDto<ItemDto>), 200)]
        public async Task<ActionResult> AddAsync(AddCommand request)
        {
            var result = await mediator.Send(request);
            return Ok(result);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ResponseDto<bool>), 200)]
        public async Task<ActionResult> UpdateAsync(Guid id, UpdateCommand request)
        {
            request.Id = id;
            var result = await mediator.Send(request);
            return Ok(result);
        }

        [HttpDelete("{Id}")]
        [ProducesResponseType(typeof(ResponseDto<bool>), 200)]
        public async Task<ActionResult> DeleteAsync([FromRoute] DeleteCommand request)
        {
            var result = await mediator.Send(request);
            return Ok(result);
        }
    }
}
