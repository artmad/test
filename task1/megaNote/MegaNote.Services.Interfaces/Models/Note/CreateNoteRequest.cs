using System.ComponentModel.DataAnnotations;

namespace MegaNote.Services.Interfaces.Models.Note
{
    public class CreateNoteRequest
    {
        [Required]
        [MaxLength(255)]
        public string FullName { get; set; }
   
        [Phone]
        public string Phone { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [MaxLength(255)]
        public string City { get; set; }
    }
}
