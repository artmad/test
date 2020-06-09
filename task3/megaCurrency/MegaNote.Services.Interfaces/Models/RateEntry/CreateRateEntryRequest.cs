using System.ComponentModel.DataAnnotations;

namespace MegaNote.Services.Interfaces.Models.Note
{
    public class CreateRateEntryRequest
    {
        public decimal DollarToRubleRate { get; set; }
        public decimal EuroToRubleRate { get; set; }
    }
}
