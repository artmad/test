using MagaNote.Domain.Interfaces;
using MegaNote.Domain.Core;
using MegaNote.Services.Interfaces;
using MegaNote.Services.Interfaces.Models.Note;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MegaNote.Infrastructure.Business
{
    public class RateEntryService : IRateEntryService
    {
        private readonly IRateEntryRepository _rateEntryRepository;
        public RateEntryService(IRateEntryRepository rateEntryRepository)
        {
            _rateEntryRepository = rateEntryRepository;
        }

        public async Task<Guid> Create(CreateRateEntryRequest request)
        {
            var note = new RateEntry(request.DollarToRubleRate, request.EuroToRubleRate);

            _rateEntryRepository.Create(note);

            await _rateEntryRepository.SaveChangesAsync();

            return note.Id;
        }

        public async Task Update(UpdateRateEntryRequest request)
        {

            var note = GetOrThrowIfNotFound(request.Id);

            note.DollarToRubleRate = request.DollarToRubleRate;
            note.EuroToRubleRate = request.EuroToRubleRate;

            _rateEntryRepository.Update(note);
            await _rateEntryRepository.SaveChangesAsync();
        }

        public RateEntry GetDetails(Guid Id)
        {
            return GetOrThrowIfNotFound(Id);
        }

        private RateEntry GetOrThrowIfNotFound(Guid id)
        {
            var entry = _rateEntryRepository.GetById(id);

            if (entry == null)
                throw new ArgumentException($"Unable to find Entity with ID = {id}");

            return entry;
        }

        public RateEntryResponseModel[] GetAll()
        {
            return _rateEntryRepository.GetAll()
                .ToList()
                .Select(x => new RateEntryResponseModel()
                {
                    DollarToRubleRate = x.DollarToRubleRate,
                    EuroToRubleRate = x.EuroToRubleRate
                })
                .ToArray();
        }

        public async Task Delete(Guid id)
        {
            var note = GetOrThrowIfNotFound(id);
            _rateEntryRepository.Delete(note);

            await _rateEntryRepository.SaveChangesAsync();
        }
    }
}
