using System;
using System.ComponentModel.DataAnnotations;

namespace MegaNote.Domain.Core
{
    public class RateEntry: Entity
    {
        public RateEntry()
        {
            CreationDate = DateTime.UtcNow;
        }

        public RateEntry(decimal dollarToRubleRate, decimal euroToRubleRate) :this()
        {
            DollarToRubleRate = dollarToRubleRate;
            EuroToRubleRate = euroToRubleRate;
        }

        public decimal DollarToRubleRate { get; set; }
        public decimal EuroToRubleRate { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
