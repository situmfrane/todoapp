using System.ComponentModel.DataAnnotations;

namespace ToDoList.Model
{
    public class ToDoList
    {
        [Key] 
        public int Id { get; set; }
        
        [Required]
        public string TaskName { get; set; }
        
        public string Assignee { get; set; }
        public bool IsDone { get; set; }
    }
}