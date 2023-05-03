using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DataModels.Entities.Enums;
using Microsoft.EntityFrameworkCore;

namespace DataModels.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required] public RoleEnum Role { get; set; }

        [MinLength(3), MaxLength(500)]
        [Required]
        public string FullName { get; set; } = null!;

        public string? PasswordHash { get; set; }

        [EmailAddress, Required] public string Email { get; set; } = string.Empty;

        [Required] public string PhoneNumber { get; set; } = string.Empty;

        public SexEnum? Sex { get; set; }
        [ForeignKey("DateOnlyId")]
        //public int BirthdayId { get; set; }
        public DateOnly? Birthday { get; set; }

        public int? PlaceId { get; set; }

        public Place? Place { get; set; }

        public virtual IList<Message> Messages { get; set; } = new List<Message>();

        public virtual IList<Event> ParticipantEvents { get; set; } = new List<Event>();
        public virtual IList<Event> ModeratorEvents { get; set; } = new List<Event>();
        public virtual IList<Event> OrganizerEvents { get; set; } = new List<Event>();
        public virtual IList<Event> MustBeChangedEvents { get; set; } = new List<Event>();

        public static User Guest
        {
            get
            {
                var guest = new User();
                guest.Id = -1;
                guest.Role = RoleEnum.Guest;
                guest.FullName = "Гость";
                guest.Email = "guest@guest.guest";
                guest.PhoneNumber = "0";
                return guest;
            }
        }


        public static User Admin    
        {
            get
            {
                var admin = new User();
                admin.Id = 1;
                admin.Role = RoleEnum.Admin;
                admin.FullName = "admin";
                admin.Email = "MustChange@Must.Change";
                admin.PhoneNumber = "MustChange";
                admin.PasswordHash = Helpers.GetHashString("admin");
                return admin;
            }
        }
    }
}
