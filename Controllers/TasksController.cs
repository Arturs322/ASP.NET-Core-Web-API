using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        [HttpGet]
        [Route("/GetTasks")]
        public async Task<IActionResult> GetTasks()
        {
            try
            {
                var tasks = await _context.Tasks.ToListAsync();
                return Ok(tasks);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error in GetTasks: {ex}");
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpPut]
        [Route("UpdateTask/{id}")]
        public async Task<IActionResult> UpdateTask(Guid id, Tasks updatedTask)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var existingTask = await _context.Tasks.FirstOrDefaultAsync(t => t.Id == id);

                if (existingTask == null)
                {
                    return NotFound("Task not found");
                }

                existingTask.Title = updatedTask.Title;

                _context.Tasks.Update(existingTask);
                await _context.SaveChangesAsync();

                return Ok(existingTask);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error in UpdateTask: {ex}");
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpDelete]
        [Route("DeleteTask/{id}")]
        public async Task<IActionResult> DeleteTask(Guid id)
        {
            try
            {
                var taskToDelete = await _context.Tasks.FirstOrDefaultAsync(t => t.Id == id);

                if (taskToDelete == null)
                {
                    return NotFound();
                }

                _context.Tasks.Remove(taskToDelete);
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error in DeleteTask: {ex}");
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
    }
}
