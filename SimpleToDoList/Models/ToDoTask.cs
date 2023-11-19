using Microsoft.AspNetCore.Mvc;

namespace SimpleToDoList.Models
{
    public class ToDoTask 
    {
        public int Id { get; set; }
        public string Task { get; set; }
        public bool Complete { get; set; } = false;
        public DateTime CreateDate { get; set; } = DateTime.Now;
    }
}
    