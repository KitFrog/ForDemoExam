using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace DataModels.Entities
{
    public class Place
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(1), MaxLength(500)]
        public string Name { get; set; } = null!;

        public byte[]? Image { get; set; }

        public virtual IList<User> Users { get; set; } = new List<User>();
        public virtual IList<Event> Events { get; set; } = new List<Event>();
    }
}
