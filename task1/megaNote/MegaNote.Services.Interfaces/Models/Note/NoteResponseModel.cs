using System;

namespace MegaNote.Services.Interfaces.Models.Note
{
    public class NoteResponseModel
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public DateTime CreationDate { get; set; }

        public NoteResponseModel(Guid id, string fullName, string phone, string email, DateTime creationDate) : base()
        {
            Id = id;
            FullName = fullName;
            Phone = phone;
            Email = email;
            CreationDate = creationDate;
        }
    }
}
