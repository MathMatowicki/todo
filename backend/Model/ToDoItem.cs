using System.ComponentModel.DataAnnotations;
using System.Xml;
namespace Model
{

    /// <summary>
    /// Represents a to-do item.
    /// </summary>
    public class ToDoItem
    {
        [Required]
        public Guid Id { get; set; }
        public string Title { get; set; }
        public bool IsDone { get; set; }
    }
}