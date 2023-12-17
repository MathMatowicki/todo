using System.ComponentModel.DataAnnotations;
namespace DTO
{

    /// <summary>
    /// Represents a to-do item.
    /// </summary>
    public class ToDoItemDTO
    {
        public string? Title { get; set; }
        public bool IsDone { get; set; }
    }
}