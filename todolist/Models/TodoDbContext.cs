using Microsoft.EntityFrameworkCore;

namespace todolist.Models
{
    public class TodoDbContext : DbContext
    {
        public TodoDbContext(DbContextOptions<TodoDbContext> options) : base(options)
        {

        }

        public DbSet<TodoList> Todolists { get; set; }
    }
}
