using System.ComponentModel.DataAnnotations;

namespace todolist.Models
{
    public class EditTodoList
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public bool IsCompleted { get; set; }

    }
}
