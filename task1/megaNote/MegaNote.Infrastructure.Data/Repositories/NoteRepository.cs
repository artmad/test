using MagaNote.Domain.Interfaces;
using MegaNote.Domain.Core;

namespace MegaNote.Infrastructure.Data.Repositories
{
    public class NoteRepository : BaseRepository<Note>, INoteRepository
    {
        public NoteRepository(StorageContext context) : base(context) { }
    }
}
