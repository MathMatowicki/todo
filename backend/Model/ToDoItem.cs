namespace Model
{

    /// <summary>
    /// Represents a to-do item.
    /// </summary>
    public class ToDoItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsDone { get; set; }
    }
}