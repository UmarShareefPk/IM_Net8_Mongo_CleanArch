using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskManagement.Application.TaskItems.Commands;



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

        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            // Implement query and handler separately
            return Ok();
        }
    }

}
