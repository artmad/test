namespace MegaNote.Services.Interfaces
{
    using MegaNote.Domain.Core;
    using MegaNote.Services.Interfaces.Models.Note;
    using System;
    using System.Threading.Tasks;

    public interface IRateEntryService
    {
        RateEntry GetDetails(Guid Id);
        RateEntryResponseModel[] GetAll();
        Task<Guid> Create(CreateRateEntryRequest request);
        Task Update(UpdateRateEntryRequest request);
        Task Delete(Guid id);
    }
}
