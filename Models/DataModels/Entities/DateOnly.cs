using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataModels.Entities
{
    public class DateOnly
    {
        [Key]
        public int Id { get; set; }
        public DateTime Time { get; set; }

        public virtual IList<User> Users { get; set; } = new List<User>();
    }
}