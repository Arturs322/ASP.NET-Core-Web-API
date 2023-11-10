using System.ComponentModel.DataAnnotations;

namespace TasksManagerAPI.Models
{
    public class Tasks
    {        
    
    [Key]   
    public Guid Id { get; set; }
    [Required]
    public string Title { get; set; } = "Untitled Task";
    public DateTime TimeCreated { get; set; } = DateTime.Now; 
    }
}
