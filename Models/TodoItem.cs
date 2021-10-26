using System;

namespace todo_list.Models
{
    public class TodoItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Desc { get; set; }
        public bool isDone { get; set; }
        public DateTime? dueDate { get; set; }
    }
}