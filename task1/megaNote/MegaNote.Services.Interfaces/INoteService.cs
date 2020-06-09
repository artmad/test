namespace MegaNote.Services.Interfaces
{
    using MegaNote.Domain.Core;
    using MegaNote.Services.Interfaces.Models.Note;
    using System;
    using System.Threading.Tasks;

    public interface INoteService
    {
        Note GetDetails(Guid Id);
        NoteResponseModel[] GetAll();
        Task<Guid> Create(CreateNoteRequest request);
        Task Update(UpdateNoteRequest request);
        Task Delete(Guid id);
    }
}
