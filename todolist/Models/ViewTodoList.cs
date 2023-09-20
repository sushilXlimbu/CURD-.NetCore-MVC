using System.ComponentModel.DataAnnotations;

namespace todolist.Models
{
    public class ViewTodoList
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
        public string selection { get; set; }
    }
}
