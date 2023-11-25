using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace TodoApp_BackendAPI.Models
{
    public class Todo
    {
        public int TodoId { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Title { get; set; } = string.Empty;

        [MaxLength(5000)]
        public string Description { get; set; } = string.Empty;

        public bool IsCompleted { get; set; } = false;

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
