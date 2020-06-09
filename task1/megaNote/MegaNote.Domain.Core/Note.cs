using System;
using System.ComponentModel.DataAnnotations;

namespace MegaNote.Domain.Core
{
    public class Note: Entity
    {
        public Note()
        {
            CreationDate = DateTime.UtcNow;
        }

        public Note(string fullName, string phone, string email, string city):this()
        {
            FullName = fullName;
            Phone = phone;
            Email = email;
            City = city;
        }

        [MaxLength(255)]
        [Required]
        public string FullName { get; set; }

        [Phone]
        public string Phone { get; set; }
        
        [EmailAddress]
        public string Email { get; set; }
        
        public string City { get; set; }

        public DateTime CreationDate { get; set; }
    }
}
