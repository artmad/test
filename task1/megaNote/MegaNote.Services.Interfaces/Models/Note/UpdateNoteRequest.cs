using System;

namespace MegaNote.Services.Interfaces.Models.Note
{
    public class UpdateNoteRequest : CreateNoteRequest
    {
        public Guid Id { get; set; }

    }
}
