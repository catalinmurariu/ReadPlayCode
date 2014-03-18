using System.Collections.Generic;

namespace ReadPlayCode.Repositories
{
    public interface IRepository<T>
    {
        IList<T> All();
        void InsertOrUpdate(T item);
        void Delete(T item);
        T GetById(int id);
        void PersistAll();
    }
}
