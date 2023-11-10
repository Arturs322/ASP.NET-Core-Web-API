using Microsoft.AspNetCore.Mvc;
using TasksManagerAPI.Data;

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

    }
}
