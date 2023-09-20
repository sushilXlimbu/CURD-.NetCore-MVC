﻿using System.ComponentModel.DataAnnotations;

namespace todolist.Models
{
    public class AddTodoList
    {
        public DateTime Date { get; set; }
        [Required]
        public string Title { get; set; }
        [Required ]
        public string Description { get; set; }
        

    }
}
