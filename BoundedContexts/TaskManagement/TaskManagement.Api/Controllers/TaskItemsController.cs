using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shared.Common.SharedModels;
using TaskManagement.Application.TaskItems.Commands;
using TaskManagement.Application.TaskItems.Queries;
using TaskManagement.Domain.Entities;



namespace TaskManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskItemsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TaskItemsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTaskItemCommand command)
        {
            var id = await _mediator.Send(command);
            return Ok(id);//CreatedAtAction(nameof(GetById), new { id }, null);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] UpdateTaskItemCommand command)
        {
            if (id != command.Id) return BadRequest();
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _mediator.Send(new DeleteTaskItemCommand(id));
            return NoContent();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            // Implement query and handler separately
            return Ok();
        }

        [HttpGet("paged")]
        public async Task<ActionResult<PagedResult<TaskItem>>> GetPaged(
       [FromQuery] int pageSize,
       [FromQuery] int pageNumber,
       [FromQuery] string? sortBy,
       [FromQuery] string? sortDirection,
       [FromQuery] string? search)
        {
            var query = new GetTaskItemsPageQuery(pageSize, pageNumber, sortBy, sortDirection, search);
            var result = await _mediator.Send(query);

            return Ok(result);
        }
    }

}
