using System;

namespace MegaNote.Services.Interfaces.Models.Note
{
    public class UpdateRateEntryRequest : CreateRateEntryRequest
    {
        public Guid Id { get; set; }
    }
}
