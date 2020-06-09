using MagaNote.Domain.Interfaces;
using MegaCurrency.Services.Interfaces;
using MegaCurrency.Services.Interfaces.Models;
using MegaCurrency.Services.Interfaces.Models.CurrencyReport;
using MegaNote.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MegaCurrency.Infrastructure.Business
{
    public class CurrencyReportService : ICurrencyReportService
    {

        private readonly int[] _reportTimePeriodsInMinutes = new int[] { 5, 15, 30, 60 };

        private readonly IRateEntryRepository _rateEntryRepository;

        public CurrencyReportService(IRateEntryRepository rateEntryRepository)
        {
            _rateEntryRepository = rateEntryRepository;
        }

        public List<CurrencyReportItem> GetReport()
        {
            var maxTimePeriod = _reportTimePeriodsInMinutes.Max();

            var fromTime = DateTime.UtcNow.AddMinutes(-maxTimePeriod);

            var rateEntries = _rateEntryRepository.GetAll()
                .OrderBy(c => c.CreationDate)
                .Where(x => x.CreationDate >= fromTime)
                .ToList();


            var result = new List<CurrencyReportItem>();

            foreach (var periuods in _reportTimePeriodsInMinutes.OrderBy(x => x))
            {
                var from = DateTime.UtcNow.AddMinutes(-periuods);
                var reportItems = GetReportItemsFrom(from, rateEntries);

                result.AddRange(reportItems);
            }

            return result;
        }


        public List<CurrencyReportItem> GetReportItemsFrom(DateTime from, List<RateEntry> entries)
        {
            var filteredEntries = entries
                .Where(x => x.CreationDate >= from);


            var earlyEntry = filteredEntries.First();
            var lateEntry = filteredEntries.Last();

            var dollarReport = new CurrencyReportItem()
            {
                From = earlyEntry.CreationDate,
                To = lateEntry.CreationDate,
                EarlyValue = earlyEntry.DollarToRubleRate,
                LateValue = lateEntry.DollarToRubleRate,
                MinValue = filteredEntries.Min(x => x.DollarToRubleRate),
                MaxValue = filteredEntries.Max(x => x.DollarToRubleRate),
                CurrencyType = CurrencyType.Dollar
            };

            var euroReport = new CurrencyReportItem()
            {
                From = earlyEntry.CreationDate,
                To = lateEntry.CreationDate,
                EarlyValue = earlyEntry.EuroToRubleRate,
                LateValue = lateEntry.EuroToRubleRate,
                MinValue = filteredEntries.Min(x => x.EuroToRubleRate),
                MaxValue = filteredEntries.Max(x => x.EuroToRubleRate),
                CurrencyType = CurrencyType.Euro
            };

            return new List<CurrencyReportItem>() { dollarReport, euroReport };

        }
    }
}
