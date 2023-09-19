using System.ComponentModel.DataAnnotations;

namespace todolist.Models
{
    public class EditTodoList
    {
        public Guid Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public bool IsCompleted { get; set; }

    }
}
