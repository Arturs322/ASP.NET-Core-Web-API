using Microsoft.AspNetCore.Mvc;
using TasksManagerAPI.Data;
using TasksManagerAPI.Models;

namespace TasksManagerAPI.Controllers
{
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly TaskDbContext _context;

        public TasksController(TaskDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("/CreateTask")]
        public async Task<IActionResult> CreateTask(Tasks newTask)
        {

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                Tasks task = new Tasks
                {
                    Id = Guid.NewGuid(),
                    Title = newTask.Title,
                };

                _context.Tasks.Add(task);
                await _context.SaveChangesAsync();

                return Ok(task);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error in CreateTask: {ex}");
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
    }
}
