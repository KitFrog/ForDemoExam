using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace DataModels.Entities
{
    
    public class Message
    {
        [Key]
        public long Id { get; set; }

        public int UserId { get; set; }
        public User? User { get; set; }

        public DateTime PublishTime { get; set; } = DateTime.Now;   

        [MinLength(4), MaxLength(128)] public string? Title { get; set; }

        [MinLength(4), MaxLength(500)] public string Content { get; set; } = null!;
    }
}
