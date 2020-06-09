using System;
using System.Linq;
using System.Threading.Tasks;

namespace MagaNote.Domain.Interfaces
{
    public interface IBaseRepository<T>
    {
        T GetById(Guid id);

        IQueryable<T> GetAll();

        T Create(T newEntity);

        void Update(T entity);

        void Delete(T entity);

        Task SaveChangesAsync();
    }
}
