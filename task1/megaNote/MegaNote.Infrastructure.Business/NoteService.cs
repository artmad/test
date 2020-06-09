using MagaNote.Domain.Interfaces;
using MegaNote.Domain.Core;
using MegaNote.Services.Interfaces;
using MegaNote.Services.Interfaces.Models.Note;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MegaNote.Infrastructure.Business
{
    public class NoteService : INoteService
    {
        private readonly INoteRepository _noteRepository;
        public NoteService(INoteRepository noteRepository)
        {
            _noteRepository = noteRepository;
        }

        public async Task<Guid> Create(CreateNoteRequest request)
        {
            var note = new Note(request.FullName, request.Phone, request.Email, request.City);

            _noteRepository.Create(note);

            await _noteRepository.SaveChangesAsync();

            return note.Id;
        }

        public async Task Update(UpdateNoteRequest request)
        {

            var note = GetOrThrowIfNotFound(request.Id);

            note.FullName = request.FullName;
            note.Phone = request.Phone;
            note.City = request.City;
            request.Email = request.Email;

            _noteRepository.Update(note);
            await _noteRepository.SaveChangesAsync();
        }

        public Note GetDetails(Guid Id)
        {
            return GetOrThrowIfNotFound(Id);
        }

        private Note GetOrThrowIfNotFound(Guid id)
        {
            var note = _noteRepository.GetById(id);

            if (note == null)
                throw new ArgumentException($"Unable to find Entity with ID = {id}");

            return note;
        }

        public NoteResponseModel[] GetAll()
        {
            return _noteRepository.GetAll()
                .ToList()
                .Select(x => new NoteResponseModel(x.Id, x.FullName, x.Phone, x.Email, x.CreationDate))
                .ToArray();
        }

        public async Task Delete(Guid id)
        {
            var note = GetOrThrowIfNotFound(id);
            _noteRepository.Delete(note);

            await _noteRepository.SaveChangesAsync();
        }
    }
}
