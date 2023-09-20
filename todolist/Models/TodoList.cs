using System.ComponentModel.DataAnnotations;

namespace todolist.Models
{
    public class TodoList
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }

    }
}
