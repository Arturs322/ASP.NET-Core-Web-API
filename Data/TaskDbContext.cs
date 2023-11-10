using TasksManagerAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace TasksManagerAPI.Data
{
    public class TaskDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "TasksDb");
        }

        public DbSet<Tasks> Tasks { get; set; }
    }
}
