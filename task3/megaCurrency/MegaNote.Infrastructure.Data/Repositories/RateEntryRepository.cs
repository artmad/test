using MagaNote.Domain.Interfaces;
using MegaNote.Domain.Core;

namespace MegaNote.Infrastructure.Data.Repositories
{
    public class RateEntryRepository : BaseRepository<RateEntry>, IRateEntryRepository
    {
        public RateEntryRepository(StorageContext context) : base(context) { }
    }
}
