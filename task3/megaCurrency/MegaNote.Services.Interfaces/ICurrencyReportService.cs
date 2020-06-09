using MegaCurrency.Services.Interfaces.Models.CurrencyReport;
using System.Collections.Generic;

namespace MegaCurrency.Services.Interfaces
{
    public interface ICurrencyReportService
    {
        public List<CurrencyReportItem> GetReport();
    }
}
