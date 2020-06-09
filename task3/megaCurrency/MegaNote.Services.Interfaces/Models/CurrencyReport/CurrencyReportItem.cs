using System;

namespace MegaCurrency.Services.Interfaces.Models.CurrencyReport
{
    public class CurrencyReportItem
    {
        public CurrencyType CurrencyType { get; set; }
        public decimal EarlyValue { get; set; }
        public decimal LateValue { get; set; }
        public decimal MinValue { get; set; }
        public decimal MaxValue { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
    }
}
