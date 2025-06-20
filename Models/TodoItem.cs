using System.ComponentModel.DataAnnotations;

namespace ToDoWebAppList.Models;

public class TodoItem
{
    [Key]
    public int ToDoId { get; set; }
    public string? Title { get; set; }

    public bool IsComplete { get; set; }
}
