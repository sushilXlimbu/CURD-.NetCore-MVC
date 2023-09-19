using System.ComponentModel.DataAnnotations;

namespace todolist.Models
{
    public class AddTodoList
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        

    }
}
